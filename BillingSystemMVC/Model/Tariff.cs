using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.Model
{
    public class Tariff : ID
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int InternetSpeed { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
