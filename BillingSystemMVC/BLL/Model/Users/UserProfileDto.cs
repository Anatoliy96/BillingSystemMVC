using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL.Model.Users
{
    public class UserProfileDto : BillingSystemMVC.Model.Users
    {
        [Required(ErrorMessage = "Name is requred")]
        public string Name { get; set; }

        [Required(ErrorMessage = "PhoneNumber is requred")]
        public string PhoneNumber { get; set; }
    }
}
