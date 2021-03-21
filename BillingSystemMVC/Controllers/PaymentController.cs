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
        public IActionResult Register(int ClientId, decimal Amount)
        {
            PaymentBLL paymentBLL = new PaymentBLL();
            paymentBLL.RegisterPayment(ClientId, Amount);
            return RedirectToAction("Index", "Clients");
        }
    }

}
