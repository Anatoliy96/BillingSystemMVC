using BillingSystemMVC.BLL.Model;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL
{
    public class TariffBLL
    {
        public Tariff GetTariff(int id)
        {
            TariffDao tariffDao = new TariffDao();
            return tariffDao.Details(id);
        }

        public Tariff GetTariff(string name)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Tariffs.FirstOrDefault(t => t.Name == name);
        }

        public Tariffs GetTariffs()
        {
            TariffDao tariffDao = new TariffDao();
            Tariffs tariffs = new Tariffs();
            tariffs.tariffs = tariffDao.GetAll();

            return tariffs;
        }

        public List<Tariff> GetTariffCount()
        {
            TariffDao tariffDao=new TariffDao();

            return tariffDao.GetAll().ToList();
        }

        public void Add(
            string Name,
            int Price,
            int InternetSpeed)
        {
            BillingSystemContext context = new BillingSystemContext();

            Tariff tariff = new Tariff()
            {
                Name = Name,
                Price = Price,
                InternetSpeed = InternetSpeed
            };
            TariffDao tariffDao = new TariffDao();
            tariffDao.Insert(tariff);
        }

        public void UpdateTariff(
            string Name,
            int Price,
            int InternetSpeed,
            int IDNumber)
        {
            BillingSystemContext context = new BillingSystemContext();
            Tariff tariff = new Tariff()
            {
                Name = Name,
                Price = Price,
                InternetSpeed = InternetSpeed,
                IDNumber = IDNumber
            };
            TariffDao tariffDao = new TariffDao();
            tariffDao.Update(tariff);
        }
        public void DeleteTariff(int id)
        {
            BillingSystemContext context = new BillingSystemContext();
            Tariff tariff = context.Tariffs.FirstOrDefault(t => t.IDNumber == id);

            TariffDao tariffDao = new TariffDao();
            tariffDao.Delete(tariff);
        }
    }
}
