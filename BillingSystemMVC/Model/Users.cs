using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.Model
{
    public class Users : ID
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="User name is requred")]
       public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter the Password...")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match")]
        public string ConfirmPassword { get; set; }

        [ForeignKey("Profile")]

        public int ProfileID { get; set; }
    }
}
