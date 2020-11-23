namespace SuperWarmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InventoryItem",
                c => new
                    {
                        InventoryItemId = c.Int(nullable: false, identity: true),
                        UPC = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        StockNumber = c.String(nullable: false),
                        ItemName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        QuantityInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InventoryItem");
        }
    }
}
