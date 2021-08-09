using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingSystemMVC.BLL;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillingSystemMVC.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ClientsDao dao = new ClientsDao();

            return View(dao.GetAll());
        }


        [HttpPost]
        public IActionResult Register(string ClientName, decimal Amount)
        {
            PaymentBLL paymentBLL = new PaymentBLL();
            if (paymentBLL.RegisterPayment(ClientName, Amount) == null)
            {
                return RedirectToAction("Register");
            }
            return RedirectToAction("Index", "Clients");
        }
    }

}
