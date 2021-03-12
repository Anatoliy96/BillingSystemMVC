using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingSystemMVC.BLL;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystemMVC.Controllers
{
    public class TariffController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            TariffDao tariffDao = new TariffDao();
            return View(tariffDao.GetAll());
        }

        public IActionResult ViewTariff()
        {
            TariffDao tariffDao = new TariffDao();
            return View(tariffDao.GetAll());
        }

        public IActionResult AddTariff(
            string Name,
            int Price,
            int InternetSpeed)
        {
            TariffBLL tariffBLL = new TariffBLL();
            if (tariffBLL != null)
            {
                tariffBLL.Add(
                    Name,
                    Price,
                    InternetSpeed);

                return RedirectToAction("Index");
            }

            return View("AddTariff");
        }

        public IActionResult TariffDetails(int id)
        {
            TariffBLL tariffBLL = new TariffBLL();
            Tariff tariff = tariffBLL.GetTariff(id);
            if (tariff == null)
            {
                return NotFound();
            }

            return View(tariff);
        }

        [HttpGet]

        public IActionResult UpdateTariff(int IDNumber)
        {
            TariffBLL tariffBLL = new TariffBLL();
            Tariff tariff = tariffBLL.GetTariff(IDNumber);
            if (tariff == null)
            {
                return NotFound();
            }
            return View(tariff);
        }

        [HttpPost]

        public IActionResult UpdateTariff(string Name, int Price, int InternetSpeed, int IDNumber)
        {
            TariffBLL tariffBLL = new TariffBLL();
            tariffBLL.UpdateTariff(Name, Price, InternetSpeed,IDNumber);

            return RedirectToAction("TariffDetails", new { ID = IDNumber });
        }

        [HttpPost]

        public IActionResult DeleteTariff(int IDNumber)
        {
            TariffBLL tariffBLL = new TariffBLL();
            tariffBLL.DeleteTariff(IDNumber);
            return RedirectToAction("Index");
        }
    }
}
