namespace SuperWarmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemInventoryTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShippingAddress",
                c => new
                    {
                        ShippingAddressId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        LocationName = c.String(nullable: false, maxLength: 50),
                        StreetAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        StateId = c.Int(nullable: false),
                        ZipcodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShippingAddressId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShippingAddress", "CustomerId", "dbo.Customer");
            DropIndex("dbo.ShippingAddress", new[] { "CustomerId" });
            DropTable("dbo.Order");
            DropTable("dbo.OrderLineItem");
            DropTable("dbo.ShippingAddress");
        }
    }
}
