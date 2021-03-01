using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL.Model.Users
{
    public class UserProfileDto : BillingSystemMVC.Model.Users
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
