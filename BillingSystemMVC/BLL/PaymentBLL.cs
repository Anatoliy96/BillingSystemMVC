using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
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
    }
}
