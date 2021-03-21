using BillingSystemMVC.DAO;
using BillingSystemMVC.Migrations;
using BillingSystemMVC.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL
{
    public class PaymentBLL
    {
        public List<Payment> GetPaymetsTimeSpan(DateTime From, DateTime To)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Payments.Where(p => p.Date >= From && p.Date <= To).ToList();
        }

        public Payment RegisterPayment(int ClientId, decimal Amount)
        {
            try
            {
                using (BillingSystemContext context = new BillingSystemContext())
                {
                    DateTime validity = context.Clients.FirstOrDefault(c => c.IDNumber == ClientId).Validity;
                    

                    Tariff tarif = context.Clients
                        .Include(c => c.ClientTarif)
                        .FirstOrDefault(c => c.IDNumber == ClientId).ClientTarif;
                    
                    Tariff tarifa = context.Tariffs
                        .FirstOrDefault(
                        t => t.IDNumber == context.Clients.FirstOrDefault(c => c.TariffId == t.IDNumber).TariffId);


                    decimal tarifPrice = tarifa.Price;
                    decimal amount = Amount;

                    int months = Convert.ToInt32(amount / tarifPrice);

                    Payment payment = new Payment()
                    {
                        Client = ClientId,
                        Date = DateTime.Now,
                        Amount = Amount
                    };
                    validity = validity.AddMonths(months);
                    context.Payments.Add(payment);

                    context.Clients.FirstOrDefault(c => c.IDNumber == payment.Client).Validity = validity;
                    
                    context.SaveChanges();
                    return payment;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
