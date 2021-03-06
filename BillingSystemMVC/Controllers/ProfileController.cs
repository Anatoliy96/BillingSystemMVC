using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BillingSystemMVC.BLL;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillingSystemMVC.Controllers
{
    public class ProfileController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            ProfileBLL profileBll = new ProfileBLL();
            return View(profileBll.GetUserProfiles());
        }

        public IActionResult ViewAllRegisteredProfiles()
        {
            ProfileDAO dao = new ProfileDAO();
            return View(dao.GetAll());
        }
        public IActionResult ViewProfile()
        {
            ProfileDAO dao = new ProfileDAO();
            return View(dao.GetAll());
        }

        public IActionResult AddProfile(
            string PhoneNumber,
            string Name)
        {
            ProfileBLL profile = new ProfileBLL();
            if (Name != null)
            {
                profile.Add(
                PhoneNumber,
                Name);

                return RedirectToAction("ViewAllRegisteredProfiles");
            }

            return View("AddProfile");
        }

        public IActionResult ProfileDetails()
        {
            ProfileBLL profileBLL = new ProfileBLL();

            //string userName = this.User.Claims.FirstOrDefault(c => c.Type == "Name").Value;
            string userName = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            BillingSystemContext context = new BillingSystemContext();
            Users currUser = context.Users.FirstOrDefault(u => u.UserName == userName);

            Profile prof = profileBLL.GetProfile(currUser.ProfileID);

            if (prof == null)
            {
                NotFound();
            }

            return View(prof);
        }

        
        
        public IActionResult UpdateProfile(int IDNumber)
        {
            ProfileBLL profileBLL = new ProfileBLL();

            Profile profile = profileBLL.GetProfile(IDNumber);

            if (profile == null)
            {
                NotFound();
            }

            return View(profile);
        }



    [HttpPost]

        public IActionResult UpdateProfile(string PhoneNumber,string Name,int IDNumber)
        {

            //BillingSystemContext context = new BillingSystemContext();
            ProfileBLL bll = new ProfileBLL();

            bll.UpdateProfile(PhoneNumber, Name, IDNumber);
            return RedirectToAction("ProfileDetails", new { ID = IDNumber });
        }
       
        [HttpPost]
        public IActionResult DeleteProfile(int IDNumber)
        {
            ProfileBLL profileBLL = new ProfileBLL();
            profileBLL.DeleteProfile(IDNumber);
            return View("ViewAllRegisteredProfiles");
        }
    }
}
