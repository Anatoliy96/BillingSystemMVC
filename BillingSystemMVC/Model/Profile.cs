﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.Model
{
    public class Profile : ID
    {
        public string PhoneNumber { get; set; }
        public string Name { get; set; }


    }
}
