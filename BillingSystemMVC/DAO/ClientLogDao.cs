using BillingSystemMVC.Model;
using System.Collections.Generic;
using System.Linq;

namespace BillingSystemMVC.DAO
{
    public class ClientLogDao : IDao<ClientLog>
    {
        public void Delete(ClientLog Entity)
        {
            throw new System.NotImplementedException();
        }

        public List<ClientLog> GetAll()
        {
            BillingSystemContext context = new BillingSystemContext();
            return context.ClientLog.ToList();
        }

        public void Insert(ClientLog Entity)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.ClientLog.Add(Entity);
            context.SaveChanges();
        }

        public void Update(ClientLog Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
