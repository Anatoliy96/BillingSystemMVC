using BillingSystemMVC.BLL.Model;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL
{
    public class ZoneBLL
    {
        public Zone GetZone(int id)
        {
            ZoneDao dao = new ZoneDao();
            return dao.Details(id);
        }
        public Zone GetZone(string Name)
        {
            BillingSystemContext context = new BillingSystemContext();
           return context.Zones.FirstOrDefault(z => z.Town == Name);
        }

        public Zones GetZones()
        {
            ZoneDao zoneDao = new ZoneDao();
            Zones zones = new Zones();
            zones.zones = zoneDao.GetAll();

            return zones;
        }

        public void Add(
            string Town,
            string Owner)
        {
            BillingSystemContext context = new BillingSystemContext();

            Zone zone = new Zone()
            {
                Town = Town,
                Owner = Owner
            };

            ZoneDao dao = new ZoneDao();
            dao.Insert(zone);
        }

        public void UpdateZone(
            string Town,
            string Owner,
            int IDNumber)
        {
            BillingSystemContext context = new BillingSystemContext();

            Zone zone = new Zone()
            {
                Town = Town,
                Owner = Owner,
                IDNumber = IDNumber
            };
            ZoneDao dao = new ZoneDao();
            dao.Update(zone);
        }

        public void DeleteZone(int id)
        {
            BillingSystemContext context = new BillingSystemContext();

            Zone zone = context.Zones.FirstOrDefault(z => z.IDNumber == id);

            ZoneDao dao = new ZoneDao();
            dao.Delete(zone);
        }
    }
}
