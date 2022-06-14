using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.Model
{
    public class Client : ID
    {
        [Display(Name = "Име")]
        public string Name { get; set; }
        public string Adress { get; set; }
        [ForeignKey("Zones")]
        public int ZoneId { get; set; }
        public Zone ClientZone { get; set; }

        public string IPAdress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Validity { get; set; }
        
        public string Comment { get; set; }
        public DateTime Included { get; set; }
        
        [ForeignKey("Tariff")]
        public int TariffId { get; set; }
        public Tariff ClientTarif { get; set; }
    }
}
