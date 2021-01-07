using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystemMVC.Model
{
    public class ID
    {
        [Key]
        public int IDNumber { get; set; }
    }
}
