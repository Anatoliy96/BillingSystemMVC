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
        public IActionResult Register(int ClientId)
        {
            Payment pay = new Payment();
            pay.Client = ClientId;
            return View(pay);
        }


        [HttpPost]
        public IActionResult Register(Payment payment)
        {
            PaymentBLL paymentBLL = new PaymentBLL();
            paymentBLL.RegisterPayment(payment);
            return RedirectToAction("Index", "Clients");
        }
    }

}
