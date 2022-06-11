using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BillingSystemMVC.Models;
using Microsoft.AspNetCore.Authorization;
using BillingSystemMVC.BLL.BLO;

namespace BillingSystemMVC.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                ViewModelCount viewModelCount = new ViewModelCount();
                return View(viewModelCount.GetViewModels());
            }
            else
            {
                return RedirectToAction("UserLogin", "Login");
            }
        }
    }
}
