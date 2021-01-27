using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.Model
{
    public class Profile : ID
    {
        [Required(ErrorMessage = "name is requred")]
        public string UserName { get; set; }
        public string UserNameType { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match")]

        public string RepeatPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
    }
}
