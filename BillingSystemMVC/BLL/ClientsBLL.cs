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
                ClientStatusDTO newClient = new ClientStatusDTO();
                newClient.Adress = c.Adress;
                newClient.ClientTarif = c.ClientTarif;
                newClient.ClientZone = c.ClientZone;
                newClient.Comment = c.Comment;
                newClient.IDNumber = c.IDNumber;
                newClient.Included = c.Included;
                newClient.IPAdress = c.IPAdress;
                newClient.Name = c.Name;
                newClient.PhoneNumber = c.PhoneNumber;
                newClient.Validity = c.Validity;

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

        public ClientStatusDTO GetClient(int ID)
        {
            ClientsDao clientsDao = new ClientsDao();
            Client client = clientsDao.Details(ID);
            ClientStatusDTO clientDto = new ClientStatusDTO();
            clientDto.Adress = client.Adress;
            clientDto.ClientTarif = client.ClientTarif;
            clientDto.ClientZone = client.ClientZone;
            clientDto.Comment = client.Comment;
            clientDto.IDNumber = client.IDNumber;
            clientDto.Included = client.Included;
            clientDto.IPAdress = client.IPAdress;
            clientDto.Name = client.Name;
            clientDto.PhoneNumber = client.PhoneNumber;
            clientDto.Validity = client.Validity;

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
                IPAdress = null,
                PhoneNumber = PhoneNumber,
                Comment = Comment,
                Included = DateTime.Now,
                TariffId = tariff
            };
            ClientsDao dao = new ClientsDao();
            dao.Insert(client);
        }

        public List<ClientStatusDTO> GetFilteredClients(ClientFilterType FilterType, string Filter)
        {

            if (FilterType == ClientFilterType.Name)
            {
                BillingSystemContext context = new BillingSystemContext();
                List<Client> clients = context
                .Clients.Include(c => c.ClientTarif)
                .Include(c => c.ClientZone)
                .ToList();

                List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();
                foreach (Client c in clients)
                {
                    ClientStatusDTO newClient = new ClientStatusDTO();
                    newClient.Adress = c.Adress;
                    newClient.ClientTarif = c.ClientTarif;
                    newClient.ClientZone = c.ClientZone;
                    newClient.Comment = c.Comment;
                    newClient.IDNumber = c.IDNumber;
                    newClient.Included = c.Included;
                    newClient.IPAdress = c.IPAdress;
                    newClient.Name = c.Name;
                    newClient.PhoneNumber = c.PhoneNumber;
                    newClient.Validity = c.Validity;

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
                FilterByName(Filter);
                return clientsDTO;
                
            }
            else if (FilterType == ClientFilterType.Address)
            {
                BillingSystemContext context = new BillingSystemContext();

                List<Client> clients = context
                .Clients.Include(c => c.ClientTarif)
                .Include(c => c.ClientZone)
                .ToList();

                List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();

                foreach (Client c in clients)
                {
                    ClientStatusDTO newClient = new ClientStatusDTO();
                    newClient.Adress = c.Adress;
                    newClient.ClientTarif = c.ClientTarif;
                    newClient.ClientZone = c.ClientZone;
                    newClient.Comment = c.Comment;
                    newClient.IDNumber = c.IDNumber;
                    newClient.Included = c.Included;
                    newClient.IPAdress = c.IPAdress;
                    newClient.Name = c.Name;
                    newClient.PhoneNumber = c.PhoneNumber;
                    newClient.Validity = c.Validity;

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
                FilterByAddress(Filter);
                return clientsDTO;
            }
            else if (FilterType == ClientFilterType.PhoneNumber)
            {
                BillingSystemContext context = new BillingSystemContext();

                List<Client> clients = context
                .Clients.Include(c => c.ClientTarif)
                .Include(c => c.ClientZone)
                .ToList();

                List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();

                foreach (Client c in clients)
                {
                    ClientStatusDTO newClient = new ClientStatusDTO();
                    newClient.Adress = c.Adress;
                    newClient.ClientTarif = c.ClientTarif;
                    newClient.ClientZone = c.ClientZone;
                    newClient.Comment = c.Comment;
                    newClient.IDNumber = c.IDNumber;
                    newClient.Included = c.Included;
                    newClient.IPAdress = c.IPAdress;
                    newClient.Name = c.Name;
                    newClient.PhoneNumber = c.PhoneNumber;
                    newClient.Validity = c.Validity;

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
                FilterByPhoneNumber(Filter);
                return clientsDTO;
                
            }
            else if (FilterType == ClientFilterType.IPAdress)
            {
                BillingSystemContext context = new BillingSystemContext();

                List<Client> clients = context
                .Clients.Include(c => c.ClientTarif)
                .Include(c => c.ClientZone)
                .ToList();

                List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();

                foreach (Client c in clients)
                {
                    ClientStatusDTO newClient = new ClientStatusDTO();
                    newClient.Adress = c.Adress;
                    newClient.ClientTarif = c.ClientTarif;
                    newClient.ClientZone = c.ClientZone;
                    newClient.Comment = c.Comment;
                    newClient.IDNumber = c.IDNumber;
                    newClient.Included = c.Included;
                    newClient.IPAdress = c.IPAdress;
                    newClient.Name = c.Name;
                    newClient.PhoneNumber = c.PhoneNumber;
                    newClient.Validity = c.Validity;

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
                FilterByIPAdress(Filter);
                return clientsDTO;
                
            }
            else if (FilterType == ClientFilterType.comment)
            {
                BillingSystemContext context = new BillingSystemContext();

                List<Client> clients = context
                .Clients.Include(c => c.ClientTarif)
                .Include(c => c.ClientZone)
                .ToList();

                List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();

                foreach (Client c in clients)
                {
                    ClientStatusDTO newClient = new ClientStatusDTO();
                    newClient.Adress = c.Adress;
                    newClient.ClientTarif = c.ClientTarif;
                    newClient.ClientZone = c.ClientZone;
                    newClient.Comment = c.Comment;
                    newClient.IDNumber = c.IDNumber;
                    newClient.Included = c.Included;
                    newClient.IPAdress = c.IPAdress;
                    newClient.Name = c.Name;
                    newClient.PhoneNumber = c.PhoneNumber;
                    newClient.Validity = c.Validity;

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
                FilterByComment(Filter);
                return clientsDTO;
                
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
                ClientStatusDTO newClient = new ClientStatusDTO();
                newClient.Adress = c.Adress;
                newClient.ClientTarif = c.ClientTarif;
                newClient.ClientZone = c.ClientZone;
                newClient.Comment = c.Comment;
                newClient.IDNumber = c.IDNumber;
                newClient.Included = c.Included;
                newClient.IPAdress = c.IPAdress;
                newClient.Name = c.Name;
                newClient.PhoneNumber = c.PhoneNumber;
                newClient.Validity = c.Validity;

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
                ClientStatusDTO newClient = new ClientStatusDTO();
                newClient.Adress = c.Adress;
                newClient.ClientTarif = c.ClientTarif;
                newClient.ClientZone = c.ClientZone;
                newClient.Comment = c.Comment;
                newClient.IDNumber = c.IDNumber;
                newClient.Included = c.Included;
                newClient.IPAdress = c.IPAdress;
                newClient.Name = c.Name;
                newClient.PhoneNumber = c.PhoneNumber;
                newClient.Validity = c.Validity;

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
                ClientStatusDTO newClient = new ClientStatusDTO();
                newClient.Adress = c.Adress;
                newClient.ClientTarif = c.ClientTarif;
                newClient.ClientZone = c.ClientZone;
                newClient.Comment = c.Comment;
                newClient.IDNumber = c.IDNumber;
                newClient.Included = c.Included;
                newClient.IPAdress = c.IPAdress;
                newClient.Name = c.Name;
                newClient.PhoneNumber = c.PhoneNumber;
                newClient.Validity = c.Validity;

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
                ClientStatusDTO newClient = new ClientStatusDTO();
                newClient.Adress = c.Adress;
                newClient.ClientTarif = c.ClientTarif;
                newClient.ClientZone = c.ClientZone;
                newClient.Comment = c.Comment;
                newClient.IDNumber = c.IDNumber;
                newClient.Included = c.Included;
                newClient.IPAdress = c.IPAdress;
                newClient.Name = c.Name;
                newClient.PhoneNumber = c.PhoneNumber;
                newClient.Validity = c.Validity;

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
                ClientStatusDTO newClient = new ClientStatusDTO();
                newClient.Adress = c.Adress;
                newClient.ClientTarif = c.ClientTarif;
                newClient.ClientZone = c.ClientZone;
                newClient.Comment = c.Comment;
                newClient.IDNumber = c.IDNumber;
                newClient.Included = c.Included;
                newClient.IPAdress = c.IPAdress;
                newClient.Name = c.Name;
                newClient.PhoneNumber = c.PhoneNumber;
                newClient.Validity = c.Validity;

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
            string Name,
            string Adress,
            string PhoneNumber,
            int ClientZone,
            int ClientTariff,
            string PonClient,
            string Comment,
            int IDNumber)
        {
            BillingSystemContext context = new BillingSystemContext();
            

            Client client = new Client()

            {
                Name = Name,
                Adress = Adress,
                PhoneNumber = PhoneNumber,
                ZoneId = ClientZone,
                TariffId = ClientTariff,
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

        public List<ClientStatusDTO> GetActiveClients()
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Clients.Where(c => c.Validity >= DateTime.Now).ToList();

            List<Client> clients = context
                .Clients.Include(c => c.ClientTarif)
                .Include(c => c.ClientZone)
                .ToList();

            List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();
            foreach (Client c in clients)
            {
                ClientStatusDTO newClient = new ClientStatusDTO();
                newClient.Adress = c.Adress;
                newClient.ClientTarif = c.ClientTarif;
                newClient.ClientZone = c.ClientZone;
                newClient.Comment = c.Comment;
                newClient.IDNumber = c.IDNumber;
                newClient.Included = c.Included;
                newClient.IPAdress = c.IPAdress;
                newClient.Name = c.Name;
                newClient.PhoneNumber = c.PhoneNumber;
                newClient.Validity = c.Validity;

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
            BillingSystemContext context = new BillingSystemContext();
            context.Clients.Where(c => c.Validity < DateTime.Now).ToList();

            List<Client> clients = context
                .Clients.Include(c => c.ClientTarif)
                .Include(c => c.ClientZone)
                .ToList();

            List<ClientStatusDTO> clientsDTO = new List<ClientStatusDTO>();
            foreach (Client c in clients)
            {
                ClientStatusDTO newClient = new ClientStatusDTO();
                newClient.Adress = c.Adress;
                newClient.ClientTarif = c.ClientTarif;
                newClient.ClientZone = c.ClientZone;
                newClient.Comment = c.Comment;
                newClient.IDNumber = c.IDNumber;
                newClient.Included = c.Included;
                newClient.IPAdress = c.IPAdress;
                newClient.Name = c.Name;
                newClient.PhoneNumber = c.PhoneNumber;
                newClient.Validity = c.Validity;

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
