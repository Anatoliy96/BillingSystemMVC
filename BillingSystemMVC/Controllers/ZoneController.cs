using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BillingSystemMVC.BLL;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using Microsoft.AspNetCore.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace BillingSystemMVC.Controllers
{
    public class ZoneController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            ZoneDao dao = new ZoneDao();
            return View(dao.GetAll());
        }

        public IActionResult ViewZone()
        {
            ZoneDao dao = new ZoneDao();
            return View(dao.GetAll());
        }

        public IActionResult AddZone(
            string Owner,
            string Town)
        {
            ZoneBLL zone = new ZoneBLL();
            if (Owner != null)
            {
                zone.Add(
                Town,
                Owner);

                return RedirectToAction("Index");
            }

            return View("AddZone");
        }

        public IActionResult ZoneDetails(int id)
        {
            ZoneBLL zoneBLL = new ZoneBLL();
            Zone zone = zoneBLL.GetZone(id);

            if (zone == null)
            {
               NotFound();
            }
            return View(zone);
        }

        [HttpGet]
        public IActionResult UpdateZone(int IDNumber)
        {
            ZoneBLL zoneBLL = new ZoneBLL();
            Zone zone = zoneBLL.GetZone(IDNumber);
            if (zoneBLL == null)
            {
                NotFound();
            }

            return View(zone);
        }

        [HttpPost]
        public IActionResult UpdateZone(string Owner, string Town, int IDNumber)
        {
            ZoneBLL zoneBLL = new ZoneBLL();
            zoneBLL.UpdateZone(Owner, Town, IDNumber);

            return RedirectToAction("ZoneDetails", new { ID = IDNumber });
        }
        [HttpPost]
        public IActionResult DeleteZone(int IDNumber)
        {
            ZoneBLL zoneBll = new ZoneBLL();
            zoneBll.DeleteZone(IDNumber);
            return RedirectToAction("Index");
        }
    }
}
