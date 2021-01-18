using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingSystemMVC.Model;

namespace BillingSystemMVC.BLL.Model
{
    public class ClientStatusDTO : ID
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        
        public int ZoneId { get; set; }
        public Zone ClientZone { get; set; }

        public string IPAdress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Validity { get; set; }

        public string Comment { get; set; }
        public DateTime Included { get; set; }

        public int TariffId { get; set; }
        public Tariff ClientTarif { get; set; }
    }
}
