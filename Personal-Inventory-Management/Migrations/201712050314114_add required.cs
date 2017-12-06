namespace Personal_Inventory_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemHeader", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ItemHeader", new[] { "User_Id" });
            AlterColumn("dbo.ItemHeader", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ItemHeader", "User_Id");
            AddForeignKey("dbo.ItemHeader", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemHeader", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ItemHeader", new[] { "User_Id" });
            AlterColumn("dbo.ItemHeader", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ItemHeader", "User_Id");
            AddForeignKey("dbo.ItemHeader", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
