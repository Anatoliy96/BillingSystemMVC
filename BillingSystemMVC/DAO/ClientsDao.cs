using BillingSystemMVC.Controllers;
using BillingSystemMVC.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;



namespace BillingSystemMVC.DAO
{
    public class ClientsDao : IDao<Client>
    {
       
        public List<Client> GetAll()
        {
            // Create an instance of the context
            BillingSystemContext context = new BillingSystemContext();
            // Get the clients and return them
            return context.Clients.ToList();
        }

        public List<Client> GetActiveClients()
        {
            BillingSystemContext context = new BillingSystemContext();
            // context.Clients
            throw new NotImplementedException();

        }


        public List<Client> Filter(Func<Client, bool> Condition)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.Where(Condition).ToList();
        }
        
        public void Insert(Client client)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Clients.Add(client);
            context.SaveChanges();
        }

        public void Update (Client client)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Clients.Update(client);
            context.SaveChanges();
        }

        public void Delete(Client client)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Clients.Remove(client);
            context.SaveChanges();
        }

        public Client Details(int ID)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Clients.FirstOrDefault(c => c.IDNumber == ID);
        }
    }
}
