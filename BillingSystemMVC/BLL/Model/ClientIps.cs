using BillingSystemMVC.BLL.BLO;
using BillingSystemMVC.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BillingSystemMVC.BLL.Model
{
    public class ClientIps
    {
        public string IP { get; set; }
        public bool Checked { get; set; }
    }
}
