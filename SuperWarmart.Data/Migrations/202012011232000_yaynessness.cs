namespace SuperWarmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yaynessness : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderLineItem", "InventoryItemId", "dbo.InventoryItem");
            DropIndex("dbo.OrderLineItem", new[] { "InventoryItemId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.OrderLineItem", "InventoryItemId");
            AddForeignKey("dbo.OrderLineItem", "InventoryItemId", "dbo.InventoryItem", "InventoryItemId", cascadeDelete: true);
        }
    }
}
