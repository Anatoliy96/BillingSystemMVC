using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL.Model
{
    public class ClientEditDTO : BaseClientDTO
    {
        public ZonesAndTariffs ChooseZonesAndTariffs { get; set; }
    }
}
