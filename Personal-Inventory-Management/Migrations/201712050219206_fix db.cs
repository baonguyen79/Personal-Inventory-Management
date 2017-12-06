namespace Personal_Inventory_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemHistory", "ItemHeader_Id", "dbo.ItemHeader");
            DropForeignKey("dbo.ItemDetail", "ItemHeader_Id", "dbo.ItemHeader");
            RenameColumn(table: "dbo.ItemDetail", name: "ItemHeader_Id", newName: "ItemHeader_ItemHeaderId");
            RenameColumn(table: "dbo.ItemHistory", name: "ItemHeader_Id", newName: "ItemHeader_ItemHeaderId");
            RenameIndex(table: "dbo.ItemDetail", name: "IX_ItemHeader_Id", newName: "IX_ItemHeader_ItemHeaderId");
            RenameIndex(table: "dbo.ItemHistory", name: "IX_ItemHeader_Id", newName: "IX_ItemHeader_ItemHeaderId");
            DropPrimaryKey("dbo.ItemDetail");
            DropPrimaryKey("dbo.ItemHeader");
            DropPrimaryKey("dbo.ItemHistory");
            DropColumn("dbo.ItemDetail", "Id");
            DropColumn("dbo.ItemHeader", "Id");
            DropColumn("dbo.ItemHistory", "Id");
            AddColumn("dbo.ItemDetail", "ItemDetailId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ItemHeader", "ItemHeaderId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ItemHistory", "ItemHistoryId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ItemDetail", "ItemDetailId");
            AddPrimaryKey("dbo.ItemHeader", "ItemHeaderId");
            AddPrimaryKey("dbo.ItemHistory", "ItemHistoryId");
            AddForeignKey("dbo.ItemHistory", "ItemHeader_ItemHeaderId", "dbo.ItemHeader", "ItemHeaderId");
            AddForeignKey("dbo.ItemDetail", "ItemHeader_ItemHeaderId", "dbo.ItemHeader", "ItemHeaderId");

        }

        public override void Down()
        {
            AddColumn("dbo.ItemHistory", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ItemHeader", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ItemDetail", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ItemDetail", "ItemHeader_ItemHeaderId", "dbo.ItemHeader");
            DropForeignKey("dbo.ItemHistory", "ItemHeader_ItemHeaderId", "dbo.ItemHeader");
            DropPrimaryKey("dbo.ItemHistory");
            DropPrimaryKey("dbo.ItemHeader");
            DropPrimaryKey("dbo.ItemDetail");
            DropColumn("dbo.ItemHistory", "ItemHistoryId");
            DropColumn("dbo.ItemHeader", "ItemHeaderId");
            DropColumn("dbo.ItemDetail", "ItemDetailId");
            AddPrimaryKey("dbo.ItemHistory", "Id");
            AddPrimaryKey("dbo.ItemHeader", "Id");
            AddPrimaryKey("dbo.ItemDetail", "Id");
            RenameIndex(table: "dbo.ItemHistory", name: "IX_ItemHeader_ItemHeaderId", newName: "IX_ItemHeader_Id");
            RenameIndex(table: "dbo.ItemDetail", name: "IX_ItemHeader_ItemHeaderId", newName: "IX_ItemHeader_Id");
            RenameColumn(table: "dbo.ItemHistory", name: "ItemHeader_ItemHeaderId", newName: "ItemHeader_Id");
            RenameColumn(table: "dbo.ItemDetail", name: "ItemHeader_ItemHeaderId", newName: "ItemHeader_Id");
            AddForeignKey("dbo.ItemDetail", "ItemHeader_Id", "dbo.ItemHeader", "Id");
            AddForeignKey("dbo.ItemHistory", "ItemHeader_Id", "dbo.ItemHeader", "Id");
        }
    }
}
