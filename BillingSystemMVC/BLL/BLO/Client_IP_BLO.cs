using BillingSystemMVC.BLL.Model.ViewModels;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using System.Collections.Generic;
using System.Linq;

namespace BillingSystemMVC.BLL.BLO
{
    public class Client_IP_BLO
    {
        public ViewModelClient_IPs ViewClientIP(int IDNumber)
        {
            BillingSystemContext context = new BillingSystemContext();

            Client client = new Client();
            List<IPAdress> adress = new List<IPAdress>();

            ViewModelClient_IPs model = new ViewModelClient_IPs();
            model.Client = context.Clients.FirstOrDefault(c => c.IDNumber == IDNumber);
            model.IPs = context.IPS.ToList();

            return model;
        }
    }
}
