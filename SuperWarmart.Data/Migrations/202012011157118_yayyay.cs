namespace SuperWarmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yayyay : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.InventoryItem", "CategoryId");
            CreateIndex("dbo.OrderLineItem", "InventoryItemId");
            AddForeignKey("dbo.InventoryItem", "CategoryId", "dbo.InventoryItemCategory", "CategoryId", cascadeDelete: false);
            AddForeignKey("dbo.OrderLineItem", "InventoryItemId", "dbo.InventoryItem", "InventoryItemId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLineItem", "InventoryItemId", "dbo.InventoryItem");
            DropForeignKey("dbo.InventoryItem", "CategoryId", "dbo.InventoryItemCategory");
            DropIndex("dbo.OrderLineItem", new[] { "InventoryItemId" });
            DropIndex("dbo.InventoryItem", new[] { "CategoryId" });
        }
    }
}
