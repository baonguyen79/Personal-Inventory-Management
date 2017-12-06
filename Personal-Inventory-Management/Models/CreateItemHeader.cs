using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personal_Inventory_Management.Models
{
    public class CreateItemHeader
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public DateTime DateAcquired { get; set; }
        public string Note { get; set; }
    }
}