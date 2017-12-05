using Personal_Inventory_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personal_Inventory_Management.DataModels
{
    public class ItemInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var itemHeaders = new List<ItemHeader>
            {
                 new ItemHeader{ItemName="Item1", ItemDescription="for test" }
            };

            itemHeaders.ForEach(s => context.ItemHeader.Add(s));
            context.SaveChanges();


            var itemDetails = new List<ItemDetail>
            {
                new ItemDetail{DetailType="link",DetailHolder="c:/",Note=""}
            };
            itemDetails.ForEach(s => context.ItemDetail.Add(s));
            context.SaveChanges();


            var itemHistories = new List<ItemHistory>
            {
                new ItemHistory{BeginDate=DateTime.Parse("2017-01-30"),Note=""}
            };
            itemHistories.ForEach(s => context.ItemHistory.Add(s));
            context.SaveChanges();
        }
    }
}