using BillingSystemMVC.BLL.Model;
using BillingSystemMVC.BLL.Model.Users;
using BillingSystemMVC.DAO;

using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.BLL
{
    public class ProfileBLL
    {
        public Profile GetProfile(int id)
        {
            ProfileDAO profileDao = new ProfileDAO();
            return profileDao.Details(id);
        }
        public Profile GetProfile(string Name)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Profiles.FirstOrDefault(p => p.Name == Name);
        }
        public Profiles GetProfiles()
        {
            ProfileDAO profileDao = new ProfileDAO();
            Profiles profiles = new Profiles();
            profiles.profiles = profileDao.GetAll();

            return profiles;
            
        }

        public List<UserProfileDto> GetUserProfiles()
        {
            UsersBLL usersBll = new UsersBLL();
            List<UserProfileDto> output = new List<UserProfileDto>();
            foreach(Users u in usersBll.GetUsers())
            {
                UserProfileDto dto = new UserProfileDto();
                dto.IDNumber = u.IDNumber;
                dto.UserName = u.UserName;
                dto.Email = u.Email;
                ProfileDAO profileDao = new ProfileDAO();
                Profile profile = profileDao.Details(u.ProfileID);

                dto.Name = profile.Name;
                dto.PhoneNumber = profile.PhoneNumber;

                output.Add(dto);
            }

            return output;
        }

        public void Add(
            string PhoneNumber,
            string Name)
        {
            BillingSystemContext context = new BillingSystemContext();
            
            Profile profile = new Profile()
            {
                PhoneNumber = PhoneNumber,
                Name = Name
            };

            ProfileDAO dao = new ProfileDAO();
            dao.Insert(profile);
        }

        public void UpdateProfile(
            string PhoneNumber,
            string Name,
            int IDNumber)
        {
            BillingSystemContext context = new BillingSystemContext();

            Profile profile = new Profile()
            {
                PhoneNumber = PhoneNumber,
                Name = Name,
                IDNumber = IDNumber
            };

            ProfileDAO dao = new ProfileDAO();
            dao.Update(profile);
        }
            
        public void DeleteProfile(int id)
        {
            BillingSystemContext context = new BillingSystemContext();

            Profile profile = context.Profiles.FirstOrDefault(p => p.IDNumber == id);

            ProfileDAO dao = new ProfileDAO();
            dao.Delete(profile);
        }
    }
}
