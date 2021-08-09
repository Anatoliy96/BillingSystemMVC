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
                IPAdress = null,
                PhoneNumber = PhoneNumber,
                Comment = Comment,
                Included = DateTime.Now,
                Validity = DateTime.Now,
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
            string Name,
            string Adress,
            string PhoneNumber,
            int Tariff,
            int Zone,
            string PonClient,
            string Comment,
            int IDNumber)
        {
            ClientsDao dao = new ClientsDao();

            Client oldClient = dao.Details(IDNumber);

            Client client = new Client()

            {
                Name = Name,
                Adress = Adress,
                PhoneNumber = PhoneNumber,
                ZoneId = Tariff,
                TariffId = Zone,
                Comment = Comment,
                IDNumber = IDNumber,
                Validity = oldClient.Validity,
                Included = oldClient.Included
            };
            
            
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
