using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.Model
{
    public class UserRoleMapping : ID
    {
        [ForeignKey("UserID")]

        public int UserID { get; set; }
        [ForeignKey("RoleID")]

        public int RoleID { get; set; }

    }
}
