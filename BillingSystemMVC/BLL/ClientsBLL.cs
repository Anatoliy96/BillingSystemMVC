using BillingSystemMVC.BLL.Model;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL
{
    public class ClientsBLL
    {
        public Client GetClient(int ID)
        {
            ClientsDao clientsDao = new ClientsDao();
           return clientsDao.Details(ID);
        }
        public enum ClientFilterType
        {
            Name,
            Address,
            PhoneNumber,
            IPAdress,
            comment
        }
        public ZonesAndTariffs GetZonesAndTariffs()
        {
            ZoneDao zoneDao = new ZoneDao();
            TariffDao tariffDao = new TariffDao();
            ZonesAndTariffs zonesAndTariffs = new ZonesAndTariffs();
            zonesAndTariffs.Tariffs = tariffDao.GetAll();
            zonesAndTariffs.Zones = zoneDao.GetAll();
            return zonesAndTariffs;
        }

        public void Add(
            string ClientName,
            string Address,
            string PhoneNumber,
            string Tariff,
            string Zone,
            string PonClient,
            string Comment)
        {
            BillingSystemContext context = new BillingSystemContext();
            int zone = context.Zones.FirstOrDefault(z => z.Town == Zone).IDNumber;
            int tariff = context.Tariffs.FirstOrDefault(t => t.Name == Tariff).IDNumber;
            Client client = new Client()
            {
                Name = ClientName,
                Adress = Address,
                ZoneId = zone,
                IPAdress = null,
                PhoneNumber = PhoneNumber,
                Comment = Comment,
                Included = DateTime.Now,
                TariffId = tariff
            };
            ClientsDao dao = new ClientsDao();
            dao.Insert(client);
        }

        public List<Client> GetFilteredClients(ClientFilterType FilterType, string Filter)
        {

            if (FilterType == ClientFilterType.Name)
            {
                return FilterByName(Filter);
            }
            else if (FilterType == ClientFilterType.Address)
            {
                return FilterByAddress(Filter);
            }
            else if (FilterType == ClientFilterType.PhoneNumber)
            {
                return FilterByPhoneNumber(Filter);
            }
            else if (FilterType == ClientFilterType.IPAdress)
            {
                return FilterByIPAdress(Filter);
            }
            else if (FilterType == ClientFilterType.comment)
            {
                return FilterByComment(Filter);
            }
            throw new InvalidEnumArgumentException("No such filter type.");
        }

        private List<Client> FilterByName(string Name)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.Where(c => c.Name.ToLower().Contains(Name.ToLower())).ToList();
        }

        private List<Client> FilterByAddress(string Address)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.Where(c => c.Adress.ToLower().Contains(Address.ToLower())).ToList();
        }

        private List<Client> FilterByPhoneNumber(string PhoneNumber)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.Where(c => c.PhoneNumber.Contains(PhoneNumber)).ToList();
        }

        private List<Client> FilterByIPAdress(string IPAdress)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.Where(c => c.IPAdress.Contains(IPAdress)).ToList();
        }

        private List<Client> FilterByComment(string Comment)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.Where(c => c.Comment.ToLower().Contains(Comment.ToLower())).ToList();
        }

        public void UpdateClient(
            string Name,
            string Adress,
            string PhoneNumber,
            int ZoneId,
            int TariffId,
            string PonClient,
            string Comment,
            int IDNumber)
        {
            BillingSystemContext context = new BillingSystemContext();
            //int zone = context.Zones.FirstOrDefault(z => z.Town == ZoneId).IDNumber;
            //int tariff = context.Tariffs.FirstOrDefault(t => t.Name == TariffId).IDNumber;

            Client client = new Client()
            {
                Name = Name,
                Adress = Adress,
                PhoneNumber = PhoneNumber,
                ZoneId = ZoneId,
                TariffId = TariffId,
                Comment = Comment,
                IDNumber = IDNumber

            };

            ClientsDao dao = new ClientsDao();
            dao.Update(client);
        }

        public void DeleteClient(int IDNumber)
        {
            BillingSystemContext context = new BillingSystemContext();
            Client client = context.Clients.FirstOrDefault(c => c.IDNumber == IDNumber);
            ClientsDao dao = new ClientsDao();
            dao.Delete(client);
        }

        public List<Client> GetActiveClients()
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.Where(c => c.Validity >= DateTime.Now).ToList();
            
        }

        public List<Client> GetInActiveClients()
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.Where(c => c.Validity < DateTime.Now).ToList();
        }

        public List<Client> GetExpiringClients()
        {
            BillingSystemContext context = new BillingSystemContext();

            return context.Clients.Where(c => c.Validity > DateTime.Now.AddDays(-5) && c.Validity <= DateTime.Now).ToList();
        }

        public List<Client> GetClientsByTariff(string FilterTariff)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.Include(c => c.TariffId).Where(c => c.ClientTarif.Name == FilterTariff).ToList();
        }

        public bool HasExpiredClients()
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.Any(c => c.Validity > DateTime.Now);
        }

        public List<Client> GetClientsByZone(string Zone)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.Include(c => c.Name).Where(c => c.ClientZone.Town == Zone).ToList();
        }

        public List<Client> GetClientsByZoneID(int ZoneId)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.Include(c => c.IDNumber).Where(c => c.ClientZone.IDNumber == ZoneId).ToList();
        }
    }
}
