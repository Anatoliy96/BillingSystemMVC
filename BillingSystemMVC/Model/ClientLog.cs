﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingSystemMVC.Model
{
    public class ClientLog : ID
    {
        [ForeignKey("Clients")]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
