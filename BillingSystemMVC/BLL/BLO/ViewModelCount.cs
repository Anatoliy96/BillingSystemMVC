using BillingSystemMVC.BLL.Model;
using BillingSystemMVC.BLL.Model.ViewModel;
using System.Linq;

namespace BillingSystemMVC.BLL.BLO
{
    public class ViewModelCount
    {
        public ViewModel GetViewModels() 
        {
            ClientsBLL clientsBLL = new ClientsBLL();
            ZoneBLL zoneBLL = new ZoneBLL();
            TariffBLL tariffBLL = new TariffBLL();

            return new ViewModel
            {
                ClientCount = clientsBLL.GetAll().Count(),
                ZoneCount = zoneBLL.GetZonesCount().Count(),
                TarriffCount = tariffBLL.GetTariffCount().Count(),
                ActiveClientCount = clientsBLL.GetActiveClients().Count()
            };
        }
    }
}
