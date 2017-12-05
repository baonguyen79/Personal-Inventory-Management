namespace Personal_Inventory_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DetailType = c.String(),
                        DetailHolder = c.String(),
                        Note = c.String(),
                        ItemHeader_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemHeader", t => t.ItemHeader_Id)
                .Index(t => t.ItemHeader_Id);
            
            CreateTable(
                "dbo.ItemHeader",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemDescription = c.String(),
                        DateAcquired = c.DateTime(nullable: false),
                        Note = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ItemHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        ItemHeader_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemHeader", t => t.ItemHeader_Id)
                .Index(t => t.ItemHeader_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemHeader", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ItemDetail", "ItemHeader_Id", "dbo.ItemHeader");
            DropForeignKey("dbo.ItemHistory", "ItemHeader_Id", "dbo.ItemHeader");
            DropIndex("dbo.ItemHistory", new[] { "ItemHeader_Id" });
            DropIndex("dbo.ItemHeader", new[] { "User_Id" });
            DropIndex("dbo.ItemDetail", new[] { "ItemHeader_Id" });
            DropTable("dbo.ItemHistory");
            DropTable("dbo.ItemHeader");
            DropTable("dbo.ItemDetail");
        }
    }
}
