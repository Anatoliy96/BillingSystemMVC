using BillingSystemMVC.BLL.Model;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL
{
    public class ClientsBLL
    {
        private BaseClientDTO ModelToDto<TDto>(Client client)
            where TDto : BaseClientDTO
        {
            TDto clientDto = (TDto)Activator.CreateInstance(typeof(TDto));


            PropertyInfo[] t1 = client.GetType()
              .GetProperties();
            PropertyInfo[] t2 = clientDto
                          .GetType()
                          .GetProperties();

            foreach (PropertyInfo f in client.GetType()
              .GetProperties()
              .Where(f => clientDto
                          .GetType()
                          .GetProperties()
                          .Any(fields => fields.Name == f.Name)))
          {
              clientDto.GetType().GetProperty(f.Name).SetValue(clientDto,
                  client.GetType().GetProperty(f.Name).GetValue(client));
          }

            return clientDto;
        }
        public List<ClientStatusDTO> GetAll()
        {
            BillingSystemContext context = new BillingSystemContext();
            List<Client> clients = context
                .Clients.Include(c => c.ClientTarif)
                .Include(c => c.ClientZone)
                .ToList();

            List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();
            foreach(Client c in clients)
            {
                ClientStatusDTO newClient = (ClientStatusDTO)ModelToDto<ClientStatusDTO>(c);
                

                if (newClient.Validity >= DateTime.Now)
                {
                    newClient.Status = "ACTIVE";
                }
                else
                {
                    newClient.Status = "INACTIVE";
                }

                newClient.IPS = context.IPS
                    .Where(ip => ip.ClientID == c.IDNumber)
                    .Select(ip => ip.IPS)
                    .ToArray();

                clientsDTO.Add(newClient);
            }

            return clientsDTO;
        }

        public ClientEditDTO GetClientEdit(int ClientId)
        {
            ClientsDao dao = new ClientsDao();

            ClientEditDTO edit = (ClientEditDTO)ModelToDto<ClientEditDTO>(dao.Details(ClientId));

            edit.ChooseZonesAndTariffs = GetZonesAndTariffs();
            return edit;
        }
        public ClientStatusDTO GetClient(int ID)
        {
            BillingSystemContext context = new BillingSystemContext();
            Client client = context.Clients
                .Include(c => c.ClientTarif)
                .Include(c => c.ClientZone)
                .FirstOrDefault(c => c.IDNumber == ID);

            ClientStatusDTO clientDto = (ClientStatusDTO)ModelToDto<ClientStatusDTO>(client);
            if (clientDto.Validity >= DateTime.Now)
            {
                clientDto.Status = "ACTIVE";
            }
            else
            {
                clientDto.Status = "INACTIVE";
            }

            return clientDto;
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
                PhoneNumber = PhoneNumber,
                Comment = Comment,
                Included = DateTime.Now,
                Validity = DateTime.Now,
                TariffId = tariff
            };
            ClientsDao dao = new ClientsDao();
            dao.Insert(client);
            ClientLog log = new ClientLog()
            {
                ClientId = client.IDNumber,
                ClientName = client.Name,
                Date = DateTime.Now,
                Text = "Добавен клиент"
            };
            ClientLogDao clientLog = new ClientLogDao();
            clientLog.Insert(log);
        }

        public List<ClientStatusDTO> GetFilteredClients(ClientFilterType FilterType, string Filter)
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

        private List<ClientStatusDTO> FilterByName(string Name)
        {
            BillingSystemContext context = new BillingSystemContext();
            
            List<Client> clients = context.Clients
                .Include(c => c.ClientZone)
                .Include(c => c.ClientTarif)
                .Where(c => c.Name.ToLower().Contains(Name.ToLower()))
                .ToList();

            List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();
            foreach (Client c in clients)
            {
                ClientStatusDTO newClient = (ClientStatusDTO)ModelToDto<ClientStatusDTO>(c);
               

                if (newClient.Validity >= DateTime.Now)
                {
                    newClient.Status = "ACTIVE";
                }
                else
                {
                    newClient.Status = "INACTIVE";
                }
                clientsDTO.Add(newClient);
            }

            return clientsDTO;
             
           
        }

        private List<ClientStatusDTO> FilterByAddress(string Address)
        {
            BillingSystemContext context = new BillingSystemContext();
            

            List<Client> clients = context.Clients.Include(c => c.ClientZone).Include(c => c.ClientTarif)
                .Where(c => c.Adress.ToLower()
                .Contains(Address.ToLower())).ToList();

            List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();
            foreach (Client c in clients)
            {
                ClientStatusDTO newClient = (ClientStatusDTO)ModelToDto<ClientStatusDTO>(c);
             

                if (newClient.Validity >= DateTime.Now)
                {
                    newClient.Status = "ACTIVE";
                }
                else
                {
                    newClient.Status = "INACTIVE";
                }
                clientsDTO.Add(newClient);
            }

            return clientsDTO;
        }

        private List<ClientStatusDTO> FilterByPhoneNumber(string PhoneNumber)
        {
            BillingSystemContext context = new BillingSystemContext();
            

            List<Client> clients = context.Clients.Include(c => c.ClientZone).Include(c => c.ClientTarif)
                .Where(c => c.PhoneNumber
                .Contains(PhoneNumber)).ToList();

            List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();
            foreach (Client c in clients)
            {
                ClientStatusDTO newClient = (ClientStatusDTO)ModelToDto<ClientStatusDTO>(c);
                

                if (newClient.Validity >= DateTime.Now)
                {
                    newClient.Status = "ACTIVE";
                }
                else
                {
                    newClient.Status = "INACTIVE";
                }
                clientsDTO.Add(newClient);
            }

            return clientsDTO;
        }

        private List<ClientStatusDTO> FilterByIPAdress(string IPAdress)
        {
            BillingSystemContext context = new BillingSystemContext();
            

            List<Client> clients = context.Clients.Include(c => c.ClientZone).Include(c => c.ClientTarif)
                .Where(c => c.IPAdress
                .Contains(IPAdress)).ToList();

            List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();
            foreach (Client c in clients)
            {
                ClientStatusDTO newClient = (ClientStatusDTO)ModelToDto<ClientStatusDTO>(c);
                

                if (newClient.Validity >= DateTime.Now)
                {
                    newClient.Status = "ACTIVE";
                }
                else
                {
                    newClient.Status = "INACTIVE";
                }
                clientsDTO.Add(newClient);
            }

            return clientsDTO;
        }

        private List<ClientStatusDTO> FilterByComment(string Comment)
        {
            BillingSystemContext context = new BillingSystemContext();
            

            List<Client> clients = context.Clients.Include(c => c.ClientZone).Include(c => c.ClientTarif)
                .Where(c => c.Comment.ToLower()
                .Contains(Comment.ToLower())).ToList();

            List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();
            foreach (Client c in clients)
            {
                ClientStatusDTO newClient = (ClientStatusDTO)ModelToDto<ClientStatusDTO>(c);
             

                if (newClient.Validity >= DateTime.Now)
                {
                    newClient.Status = "ACTIVE";
                }
                else
                {
                    newClient.Status = "INACTIVE";
                }
                clientsDTO.Add(newClient);
            }

            return clientsDTO;
        }

        public void UpdateClient(
            ClientEditDTO clientDto)
        {
            ClientsDao dao = new ClientsDao();

            Client oldClient = dao.Details(clientDto.IDNumber);


            Client client = new Client()

            {
                Name = clientDto.Name,
                Adress = clientDto.Adress,
                PhoneNumber = clientDto.PhoneNumber,
                ZoneId = clientDto.ZoneId,
                TariffId = clientDto.TariffId,
                Comment = clientDto.Comment,
                IDNumber = clientDto.IDNumber,
                Validity = oldClient.Validity,
                Included = oldClient.Included
            };
            // Put in logs
            ClientLog clientLog = new ClientLog();
            clientLog.Text = string.Join("\n", GetChanges(oldClient, client));
            clientLog.Date = DateTime.Now;
            clientLog.ClientId = clientDto.IDNumber;
            clientLog.ClientName = clientDto.Name;
            ClientLogDao clientLogDao = new ClientLogDao();
            clientLogDao.Insert(clientLog);

            dao.Update(client);
            
        }

        private List<string> GetChanges(Client oldCLient, Client newClient)
        {
            List<string> changes = new List<string>();
            if (oldCLient.Name != newClient.Name)
            {
                changes.Add($"Имената са променени от {oldCLient.Name} на {newClient.Name}.");
            }
            if (oldCLient.Adress != newClient.Adress)
            {
                changes.Add($"Адреса на клиента е променрн от {oldCLient.Adress} на {newClient.Adress}.");
            }
            if (oldCLient.PhoneNumber != newClient.PhoneNumber)
            {
                changes.Add($"Телефонният номер на клиента е променен от {oldCLient.PhoneNumber} на {newClient.PhoneNumber}.");
            }
            if (oldCLient.ZoneId != newClient.ZoneId)
            {
                changes.Add($"Зоната на клиента е променен от {oldCLient.ZoneId} на {newClient.ZoneId}.");
            }
            if (oldCLient.TariffId != newClient.TariffId)
            {
                changes.Add($"Тарифата на клиента е променен от {oldCLient.TariffId} на {newClient.TariffId}.");
            }
            return changes;
        }

        public void DeleteClient(int IDNumber)
        {
            BillingSystemContext context = new BillingSystemContext();
            Client client = context.Clients.FirstOrDefault(c => c.IDNumber == IDNumber);
            ClientsDao dao = new ClientsDao();
            dao.Delete(client);
        }

        public List<ClientStatusDTO> GetActiveClients()
        {
            return GetClientStatusDTOs().Where(c => c.Status == "ACTIVE").ToList();

        }

        private List<ClientStatusDTO> GetClientStatusDTOs()
        {
            BillingSystemContext context = new BillingSystemContext();

            List<Client> clients = context
                .Clients.Include(c => c.ClientTarif)
                .Include(c => c.ClientZone)
                .ToList();

            List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();
            foreach (Client c in clients)
            {
                ClientStatusDTO newClient = (ClientStatusDTO)ModelToDto<ClientStatusDTO>(c);


                if (newClient.Validity >= DateTime.Now)
                {
                    newClient.Status = "ACTIVE";
                }
                else
                {
                    newClient.Status = "INACTIVE";
                }
                clientsDTO.Add(newClient);
            }

            return clientsDTO;
        }

        public List<ClientStatusDTO> GetInActiveClients()
        {
            return GetClientStatusDTOs().Where(c => c.Status == "INACTIVE").ToList();
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
