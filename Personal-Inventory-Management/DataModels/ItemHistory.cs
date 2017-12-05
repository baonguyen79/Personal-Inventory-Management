using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personal_Inventory_Management.DataModels
{
    public class ItemHistory
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
    }
}