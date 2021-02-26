using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BillingSystemMVC.BLL;
using BillingSystemMVC.BLL.Model.Users;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystemMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin([Bind] Users user)
        {
            
            BillingSystemContext context = new BillingSystemContext();
            if (context.Users.Any(u => u.UserName == user.UserName && u.Password == user.Password))
            {
                UsersBLL usersBLL = new UsersBLL();
                UserClaimsDto userRoles = usersBLL.GetUserClaims(user.UserName);
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, userRoles.UserName),
                    new Claim(ClaimTypes.Email, userRoles.Email),
                };

                foreach(RoleMaster rm in userRoles.Roles)
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, rm.RollName));
                }

                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }

            return View(user);


        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        
        }
    }
}
