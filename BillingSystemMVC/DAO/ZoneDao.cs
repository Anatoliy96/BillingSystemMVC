
using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.DAO
{
    public class ZoneDao : IDao<Zone>
    {
        public List<Zone> GetAll()
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Zones.ToList();
        }

        public void Insert(Zone zone)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Zones.Add(zone);
            context.SaveChanges();
        }

        public void Update(Zone zone)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Zones.Update(zone);
            context.SaveChanges();
        }

        public void Delete(Zone zone)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Zones.Remove(zone);
            context.SaveChanges();
        }

        public Zone Details(int ID)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Zones.FirstOrDefault(p => p.IDNumber == ID);
        }
    }
}
