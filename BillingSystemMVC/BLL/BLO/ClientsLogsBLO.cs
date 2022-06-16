using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using System.Collections.Generic;
using System.Linq;

namespace BillingSystemMVC.BLL.BLO
{
    public class ClientsLogsBLO
    {
        public List<ClientLog> GetClientByLog(int ClientID)
        {
            ClientLogDao log = new ClientLogDao();
            return log.GetAll().Where(c => c.ClientId == ClientID).ToList();
            
        }
    }
}
