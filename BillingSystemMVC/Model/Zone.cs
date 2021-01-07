using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.Model
{
    public class Zone : ID
    {
        public string Town { get; set; }
        public string Owner { get; set; }
        public string Tariff { get; set; }
        public string WorkingIPAdresses { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
