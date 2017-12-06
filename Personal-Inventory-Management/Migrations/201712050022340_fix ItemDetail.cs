namespace Personal_Inventory_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixItemDetail : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ItemDetail", newName: "ItemDetails");
            RenameTable(name: "dbo.ItemHeader", newName: "ItemHeaders");
            RenameTable(name: "dbo.ItemHistory", newName: "ItemHistories");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ItemHistories", newName: "ItemHistory");
            RenameTable(name: "dbo.ItemHeaders", newName: "ItemHeader");
            RenameTable(name: "dbo.ItemDetails", newName: "ItemDetail");
        }
    }
}
