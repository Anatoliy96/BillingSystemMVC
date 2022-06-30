using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingSystemMVC.Model;

namespace BillingSystemMVC.BLL.Model
{
    public class ClientStatusDTO : BaseClientDTO
    {
        public string Status { get; set; }
        
        public Zone ClientZone { get; set; }

        public string[] IPS { get; set; }
        
        public Tariff ClientTarif { get; set; }
    }
}
