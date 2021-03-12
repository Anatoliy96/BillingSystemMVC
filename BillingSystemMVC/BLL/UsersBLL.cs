using BillingSystemMVC.BLL.Model.Users;
using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scrypt;
using System.Security.Cryptography;
using System.Text;

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

        public void RegisterUser(UserProfileDto profileDto)
        {
            
            Profile profile = new Profile();

            profile.Name = profileDto.Name;
            profile.PhoneNumber = profileDto.PhoneNumber;

            BillingSystemContext context = new BillingSystemContext();
            context.Profiles.Add(profile);
            context.SaveChanges();
            Users user = new Users();
            user.UserName = profileDto.UserName;
            user.Email = profileDto.Email;
            user.Password = SecurePasswordHasher.Hash(profileDto.Password);
            user.ConfirmPassword = SecurePasswordHasher.Hash(profileDto.ConfirmPassword);

            user.ProfileID = profile.IDNumber;
            context.Users.Add(user);

            context.SaveChanges();
        } 

        public List<Users> GetUsers()
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Users.ToList();
        }
    }
}
