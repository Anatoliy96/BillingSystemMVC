
using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.DAO
{
    public class TariffDao : IDao<Tariff>
    {
        public List<Tariff> GetAll()
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Tariffs.ToList();
        }
        public void Insert(Tariff tariff)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Tariffs.Add(tariff);
            context.SaveChanges();
        }

        public void Update(Tariff tariff)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Tariffs.Update(tariff);
            context.SaveChanges();
        }

        public void Delete(Tariff tariff)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Tariffs.Remove(tariff);
            context.SaveChanges();
        }

        public Tariff Details(int ID)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Tariffs.FirstOrDefault(t => t.IDNumber == ID);
        }
    }
}
