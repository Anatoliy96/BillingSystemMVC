using BillingSystemMVC.BLL.Model;
using BillingSystemMVC.Model;
using System.Collections.Generic;
using System.Linq;

namespace BillingSystemMVC.DAO
{
    public class IPSDao : IDao<IPAdress>
    {
        public void Delete(IPAdress Entity)
        {
            throw new System.NotImplementedException();
        }

        public List<IPAdress> GetAll()
        {
            BillingSystemContext context = new BillingSystemContext();

            return context.IPS.ToList();
        }

        public void Insert(IPAdress IP)
        {
            BillingSystemContext context = new BillingSystemContext();
            context.IPS.Add(IP);
            context.SaveChanges();
        }

        public void Update(IPAdress Entity)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateIps(int clientId, List<ClientIps> ips)
        {
            BillingSystemContext context = new BillingSystemContext();
            foreach (ClientIps ip in ips)
            {
                IPAdress ipAddress = context.IPS.First(e => e.IPS == ip.IP);
                if (ip.Checked)
                {
                    ipAddress.Status = Status.Зает.ToString();
                    ipAddress.ClientID = clientId;
                }
            }

            context.SaveChanges();
        }
    }
}
