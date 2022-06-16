using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingSystemMVC.BLL;
using BillingSystemMVC.BLL.BLO;
using BillingSystemMVC.BLL.Model;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace BillingSystemMVC.Controllers
{
   
    public class ClientsController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ActiveClients()
        {
            ClientsBLL clientsBLL = new ClientsBLL();
            return View(clientsBLL.GetActiveClients());
        }

        public IActionResult InActiveClients()
        {
            ClientsBLL clientsBLL = new ClientsBLL();
            return View(clientsBLL.GetInActiveClients());
        }

        public IActionResult ViewAllClients()
        {
            ClientsBLL bll = new ClientsBLL();
            return View(bll.GetAll());
        }

        public IActionResult ViewFilteredClients(string FilterType, string Filter)
        {
            ClientsBLL clientsBLL = new ClientsBLL();


            if (FilterType == "name")
            {
                return View(clientsBLL.GetFilteredClients(ClientsBLL.ClientFilterType.Name, Filter));
            }
            else if (FilterType == "address")
            {
                return View(clientsBLL.GetFilteredClients(ClientsBLL.ClientFilterType.Address, Filter));
            }
            else if (FilterType == "PhoneNumber")
            {
                return View(clientsBLL.GetFilteredClients(ClientsBLL.ClientFilterType.PhoneNumber, Filter));
            }
            else if (FilterType == "IPAdress")
            {
                return View(clientsBLL.GetFilteredClients(ClientsBLL.ClientFilterType.IPAdress, Filter));
            }
            else if (FilterType == "Comment")
            {
                return View(clientsBLL.GetFilteredClients(ClientsBLL.ClientFilterType.comment, Filter));
            }


            throw new NotImplementedException();
        }

        public IActionResult AddClient(
            string ClientName, 
            string Address, 
            string PhoneNumber, 
            string Tariff, 
            string Zone, 
            string PonClient, 
            string Comment)
        {
            ClientsBLL clients = new ClientsBLL();
            if (ClientName != null)
            {
                
                clients.Add(
                    ClientName,
                    Address,
                    PhoneNumber,
                    Tariff,
                    Zone,
                    PonClient,
                    Comment);

                return RedirectToAction("ViewAllClients");
            }
            
            
            return View(clients.GetZonesAndTariffs());
        }

        public IActionResult ClientDetails(int ID)
        {
            ClientsBLL clientsBLL = new ClientsBLL();
            ClientStatusDTO client = clientsBLL.GetClient(ID);
            

            if (client == null)
            {
                NotFound();
            }

            return View(client);
        }
        
        public IActionResult UpdateClient(int IDNumber)
        {
            ClientsBLL clientsBLL = new ClientsBLL();
            ClientEditDTO client = clientsBLL.GetClientEdit(IDNumber);

            if (client == null)
            {
                NotFound();
            }

            return View(client);
        }

        [HttpPost]

        public IActionResult UpdateClient(
            ClientEditDTO client)
        {

            ClientsBLL bll = new ClientsBLL();

            bll.UpdateClient(client);
            return RedirectToAction("ClientDetails", new { ID = client.IDNumber });

        }

        [HttpGet]

        public IActionResult GetClientChanges(int IDNumber)
        {
            ClientsLogsBLO clientsLogsBLO = new ClientsLogsBLO();
            return View(clientsLogsBLO.GetClientByLog(IDNumber));
        }

        [HttpPost]
        [Authorize(Roles = "Owner,Admin")]
        public IActionResult DeleteClient(int IDNumber)
        {
            ClientsBLL clientsBLL = new ClientsBLL();
            clientsBLL.DeleteClient(IDNumber);
            return View("Index");
        }
    }
}
