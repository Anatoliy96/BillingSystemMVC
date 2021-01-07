using BillingSystemMVC.BLL.Model;
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
        public Profiles GetProfiles()
        {
            ProfileDAO profileDao = new ProfileDAO();
            Profiles profiles = new Profiles();
            profiles.profiles = profileDao.GetAll();

            return profiles;
            
        }
        public void Add(
            string UserName,
            string UserNameType,
            string Password,
            string PhoneNumber,
            string Name)
        {
            BillingSystemContext context = new BillingSystemContext();
            
            Profile profile = new Profile()
            {
                UserName = UserName,
                UserNameType = UserNameType,
                Password = Password,
                PhoneNumber = PhoneNumber,
                Name = Name
            };

            ProfileDAO dao = new ProfileDAO();
            dao.Insert(profile);
        }

        public void UpdateProfile(
            string UserName,
            string UserNameType,
            string Password,
            string PhoneNumber,
            string Name,
            int IDNumber)
        {
            BillingSystemContext context = new BillingSystemContext();

            Profile profile = new Profile()
            {
                UserName = UserName,
                UserNameType = UserNameType,
                Password = Password,
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
