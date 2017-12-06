using Personal_Inventory_Management.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personal_Inventory_Management.DataModels
{
    public class ItemHeader
    {
        public int ItemHeaderId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public DateTime DateAcquired { get; set; }
        public string Note { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<ItemDetail> ItemDetails { get; set; }
        public virtual ICollection<ItemHistory> Histories { get; set; }
    }


}