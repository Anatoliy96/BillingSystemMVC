﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Register([Bind] Users user)
        {
            try
            {
                using (BillingSystemContext context = new BillingSystemContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return RedirectToAction("UserLogin", "Login");
                }
            }
            catch (Exception ex)
            {

            }

            return View(); 

        }
    }
}
