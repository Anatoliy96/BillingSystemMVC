using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingSystemMVC.BLL;
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
            ClientsDao clientsDao = new ClientsDao();

            Client client = clientsDao.Details(IDNumber);

            if (client == null)
            {
                NotFound();
            }

            return View(client);
        }

        [HttpPost]

        public IActionResult UpdateClient(
            string Name,
            string Adress,
            string PhoneNumber,
            int ZoneId,
            int TariffId,
            string PonClient,
            string Comment,
            int IDNumber)
        {

            ClientsBLL bll = new ClientsBLL();

            bll.UpdateClient(Name, Adress, PhoneNumber, ZoneId, TariffId, PonClient, Comment, IDNumber);
            return RedirectToAction("ClientDetails", new { ID = IDNumber });

        }

        [HttpPost]
        public IActionResult DeleteClient(int IDNumber)
        {
            ClientsBLL clientsBLL = new ClientsBLL();
            clientsBLL.DeleteClient(IDNumber);
            return View("Index");
        }
    }
}
