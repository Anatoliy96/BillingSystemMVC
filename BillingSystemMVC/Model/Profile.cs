using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.Model
{
    public class Profile : ID
    {
        public string UserName { get; set; }
        public string UserNameType { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
    }
}
