using System;
using System.Collections.Generic;
using System.Linq;
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
            ProfileDAO dao = new ProfileDAO();
            return View(dao.GetAll());
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
            string UserName,
            string UserNameType,
            string Password,
            string PhoneNumber,
            string Name)
        {
            ProfileBLL profile = new ProfileBLL();
            if (UserName != null)
            {
           profile.Add(
           UserName,
           UserNameType,
           Password,
           PhoneNumber,
           Name);
               
                return RedirectToAction("ViewAllRegisteredProfiles");
            }
            
            return View("AddProfile");
        }

        public IActionResult ProfileDetails(int ID)
        {
            ProfileBLL profileBLL = new ProfileBLL();

            Profile prof = profileBLL.GetProfile(ID);

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

        public IActionResult UpdateProfile(string UserName,string UserNameType,string Password,string PhoneNumber,string Name,int IDNumber)
        {

            //BillingSystemContext context = new BillingSystemContext();
            ProfileBLL bll = new ProfileBLL();

            bll.UpdateProfile(UserName, UserNameType, Password, PhoneNumber, Name, IDNumber);
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
