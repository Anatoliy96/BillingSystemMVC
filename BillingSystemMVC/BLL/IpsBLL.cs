using BillingSystemMVC.DAO;
using BillingSystemMVC.Model;
using System;
using System.Collections.Generic;

namespace BillingSystemMVC.BLL
{
    public class IpsBLL
    {
        public List<IPAdress> GetAll()
        {
            IPSDao IPSDao = new IPSDao();
            List<IPAdress> iPAdresses = new List<IPAdress>();
            IPAdress iPAdress = new IPAdress();
            foreach (IPAdress i in iPAdresses)
            {
                if (iPAdress.Status == null)
                {
                    iPAdress.Status = "Свободен";
                }
                else
                {
                    iPAdress.Status = "Зает";
                }
                
            }

            return IPSDao.GetAll();
        }
    }
}
