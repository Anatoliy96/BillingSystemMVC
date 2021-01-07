
using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.DAO
{
    public class ProfileDAO : IDao<Profile>
    {
        
        public List<Profile> GetAll()
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Profiles.ToList();
        }
       public void Insert (Profile profile)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Profiles.Add(profile);
            context.SaveChanges();
        }

        public void Update (Profile profile )
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Profiles.Update(profile);
            context.SaveChanges();
        }

        public void Delete(Profile profile)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.Profiles.Remove(profile);
            context.SaveChanges();
        }

        public Profile Details(int ID)
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.Profiles.FirstOrDefault(p => p.IDNumber == ID);
        }
    }
}
