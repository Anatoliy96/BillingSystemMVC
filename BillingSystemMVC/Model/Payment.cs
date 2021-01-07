using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.Model
{
    public class Payment : ID
    {
        public int Client { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
