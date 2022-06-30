using BillingSystemMVC.BLL;
using BillingSystemMVC.BLL.BLO;
using BillingSystemMVC.BLL.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.Collections.Generic;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using BillingSystemMVC.DAO;

namespace BillingSystemMVC.Controllers
{
    public class IPController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllIps(int IDNumber)
        {
            Client_IP_BLO client_IP_BLO = new Client_IP_BLO();

            return View(client_IP_BLO.ViewClientIP(IDNumber));
        }

        [HttpPost]
        public IActionResult AddIpsToClient(string json)
        {
            //ClientIps clientIps;
            dynamic clientIps = JsonConvert.DeserializeObject<dynamic>(json);
            Console.WriteLine(clientIps.ips);
            int clientId = clientIps.clientId;
            List<ClientIps> ips = new List<ClientIps>();
            foreach (dynamic ip in clientIps.ips)
            {
                ips.Add(new ClientIps()
                {
                    IP = ip.ip,
                    Checked = ip.isChecked,
                }); 
            }

            IPSDao dao = new IPSDao();
            dao.UpdateIps(clientId, ips);

            return null;
        }
    }
}
