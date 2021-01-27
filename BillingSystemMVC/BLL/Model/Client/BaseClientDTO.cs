using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL.Model
{
    public class BaseClientDTO : ID
    {
        public string Name { get; set; }
        public string Adress { get; set; }

        public int ZoneId { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime Validity { get; set; }

        public string Comment { get; set; }
        public DateTime Included { get; set; }

        public int TariffId { get; set; }
    }
}
