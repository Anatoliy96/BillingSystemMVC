using BillingSystemMVC.Model;
using System.Collections.Generic;

namespace BillingSystemMVC.BLL.Model.ViewModels
{
    public class ViewModelClient_IPs
    {
        public Client Client { get; set; }
        public List<IPAdress> IPs { get; set; }
    }
}
