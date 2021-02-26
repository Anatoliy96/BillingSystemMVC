using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL.Model.Users
{
    public class UserClaimsDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public List<RoleMaster> Roles { get; set; }
    }
}
