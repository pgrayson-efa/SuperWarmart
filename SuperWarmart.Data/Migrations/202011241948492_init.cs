namespace SuperWarmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
            
            CreateTable(
                "dbo.OrderLineItem",
                c => new
                    {
                        OrderLineItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        InventoryItemId = c.Int(nullable: false),
                        QuantityOrdered = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderLineItemId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        OrderStatus = c.String(nullable: false),
                        OrderNote = c.String(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        TotalCost = c.Double(nullable: false),
                        DateOfOrder = c.DateTime(nullable: false),
                        DateShipped = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(nullable: false),
                        Abbr = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StateId);
            
            AlterColumn("dbo.Zipcode", "VerifiedZipcode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zipcode", "VerifiedZipcode", c => c.String());
            DropTable("dbo.State");
            DropTable("dbo.Order");
            DropTable("dbo.OrderLineItem");
            DropTable("dbo.InventoryItem");
        }
    }
}
