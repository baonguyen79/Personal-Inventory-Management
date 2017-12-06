namespace Personal_Inventory_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequire : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemDetail", "ItemHeader_ItemHeaderId", "dbo.ItemHeader");
            DropForeignKey("dbo.ItemHistory", "ItemHeader_ItemHeaderId", "dbo.ItemHeader");
            DropIndex("dbo.ItemDetail", new[] { "ItemHeader_ItemHeaderId" });
            DropIndex("dbo.ItemHistory", new[] { "ItemHeader_ItemHeaderId" });
            AlterColumn("dbo.ItemDetail", "ItemHeader_ItemHeaderId", c => c.Int(nullable: false));
            AlterColumn("dbo.ItemHistory", "ItemHeader_ItemHeaderId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemDetail", "ItemHeader_ItemHeaderId");
            CreateIndex("dbo.ItemHistory", "ItemHeader_ItemHeaderId");
            AddForeignKey("dbo.ItemDetail", "ItemHeader_ItemHeaderId", "dbo.ItemHeader", "ItemHeaderId", cascadeDelete: true);
            AddForeignKey("dbo.ItemHistory", "ItemHeader_ItemHeaderId", "dbo.ItemHeader", "ItemHeaderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemHistory", "ItemHeader_ItemHeaderId", "dbo.ItemHeader");
            DropForeignKey("dbo.ItemDetail", "ItemHeader_ItemHeaderId", "dbo.ItemHeader");
            DropIndex("dbo.ItemHistory", new[] { "ItemHeader_ItemHeaderId" });
            DropIndex("dbo.ItemDetail", new[] { "ItemHeader_ItemHeaderId" });
            AlterColumn("dbo.ItemHistory", "ItemHeader_ItemHeaderId", c => c.Int());
            AlterColumn("dbo.ItemDetail", "ItemHeader_ItemHeaderId", c => c.Int());
            CreateIndex("dbo.ItemHistory", "ItemHeader_ItemHeaderId");
            CreateIndex("dbo.ItemDetail", "ItemHeader_ItemHeaderId");
            AddForeignKey("dbo.ItemHistory", "ItemHeader_ItemHeaderId", "dbo.ItemHeader", "ItemHeaderId");
            AddForeignKey("dbo.ItemDetail", "ItemHeader_ItemHeaderId", "dbo.ItemHeader", "ItemHeaderId");
        }
    }
}
