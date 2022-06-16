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
        [Display(Name = "Адрес")]
        public string Adress { get; set; }
        [ForeignKey("Zones")]
        [Display(Name = "Зони")]
        public int ZoneId { get; set; }
        public Zone ClientZone { get; set; }
        [Display(Name = "IPAdress")]
        public string IPAdress { get; set; }
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Валидност")]
        public DateTime Validity { get; set; }
        [Display(Name = "Коментар")]
        public string Comment { get; set; }
        public DateTime Included { get; set; }
        
        [ForeignKey("Tariff")]
        [Display(Name = "Тарифа")]
        public int TariffId { get; set; }
        public Tariff ClientTarif { get; set; }
    }
}
