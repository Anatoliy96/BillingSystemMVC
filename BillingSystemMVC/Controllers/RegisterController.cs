using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingSystemMVC.BLL;
using BillingSystemMVC.BLL.Model.Users;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BillingSystemMVC.Controllers
{
    public class RegisterController : Controller
    {
       [HttpGet]
      public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([Bind] UserProfileDto user)
        {
            BillingSystemContext context = new BillingSystemContext();
            var registeredUserName = context.Users.Where(u => u.UserName.Equals(user.UserName)).SingleOrDefault();
            if (registeredUserName != null)
            {
                ViewBag.Error = "This user is already registered.";
                return View();
            }
            if (context.Users.Any(u => u.Email == user.Email))
            {
                ViewBag.Error = "This e-mail is already taken.";
                return View();
            }
            try
            {
                UsersBLL bll = new UsersBLL();

                bll.RegisterUser(user);
                return RedirectToAction("UserLogin", "Login");
            }
            catch (Exception ex)
            {

            }

            return View(); 

        }
    }
}
