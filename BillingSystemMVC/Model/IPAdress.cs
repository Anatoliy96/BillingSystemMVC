using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystemMVC.Model
{
    public enum Status{
        Свободен,
        Зает
    }

    public class IPAdress : ID  
    {
        public string IPS { get; set; }
        public string Status { get; set; }
        [ForeignKey("Client")]
        public int ClientID { get; set; }

    }
}
