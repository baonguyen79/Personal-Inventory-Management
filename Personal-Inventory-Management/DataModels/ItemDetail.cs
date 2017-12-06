using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Personal_Inventory_Management.DataModels
{
    public class ItemDetail
    {
        
        public int    ItemDetailId { get; set; }
        public string DetailType { get; set; }
        public string DetailHolder { get; set; }
        public string Note { get; set; }
        [Required]
        public virtual ItemHeader ItemHeader { get; set; }
    }
       
}