using BillingSystemMVC.BLL.Model.Users;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL
{
    public class UsersBLL
    {
        public UserClaimsDto GetUserClaims(string username)
        {
            UserClaimsDto userdto = new UserClaimsDto();
            BillingSystemContext context = new BillingSystemContext();
           Users user = context.Users.FirstOrDefault(u => u.UserName == username);

            userdto.UserName = user.UserName;
            userdto.Email = user.Email;

            userdto.Roles = context.RoleMasters
                .Where(r => context.UserRoleMappings
                .Any(urm => urm.RoleID == r.IDNumber && urm.UserID == user.IDNumber)).ToList();

            return userdto;
        }
    }
}
