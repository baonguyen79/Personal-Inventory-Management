namespace Personal_Inventory_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ItemDetails", newName: "ItemDetail");
            RenameTable(name: "dbo.ItemHeaders", newName: "ItemHeader");
            RenameTable(name: "dbo.ItemHistories", newName: "ItemHistory");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ItemHistory", newName: "ItemHistories");
            RenameTable(name: "dbo.ItemHeader", newName: "ItemHeaders");
            RenameTable(name: "dbo.ItemDetail", newName: "ItemDetails");
        }
    }
}
