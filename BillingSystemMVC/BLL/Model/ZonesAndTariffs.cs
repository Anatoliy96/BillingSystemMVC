using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL.Model
{
    public class ZonesAndTariffs
    {
        public List<Zone> Zones { get; set; }
        public List<Tariff> Tariffs { get; set; }
    }
}
