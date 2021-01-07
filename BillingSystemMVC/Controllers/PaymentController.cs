using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Register([Bind] Payment payment)
        {
            try
            {
                using (BillingSystemContext context = new BillingSystemContext())
                {
                    // Взимаш до кога е валидна
                    DateTime validity = context.Clients.FirstOrDefault(c => c.IDNumber == payment.Client).Validity;
                    Tariff tarif = context.Clients.Include(c => c.ClientTarif).FirstOrDefault(c => c.IDNumber == payment.Client).ClientTarif;
                    Tariff tarifa = context.Tariffs.FirstOrDefault(t => t.IDNumber == context.Clients.FirstOrDefault(c => c.TariffId == t.IDNumber).TariffId);
                    decimal tarifPrice = tarifa.Price;
                    decimal amount = payment.Amount;

                    int months = Convert.ToInt32(amount / tarifPrice);

                    validity.AddMonths(months);

                    // Хващаш колко ти е платил и добавяш спрямо сумата дни
                    // Задаваш
                    context.Payments.Add(payment);
                    

                    context.Clients.FirstOrDefault(c => c.IDNumber == payment.Client).Validity = validity;

                    context.SaveChanges();
                    return RedirectToAction("Index", "Clients");
                }

            }
            catch (Exception ex)
            {

                
            }
            return View();
        }
    }

}
