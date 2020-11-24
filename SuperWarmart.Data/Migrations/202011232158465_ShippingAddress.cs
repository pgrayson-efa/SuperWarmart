namespace SuperWarmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShippingAddress : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShippingAddress", "CustomerId", "dbo.Customer");
            DropIndex("dbo.ShippingAddress", new[] { "CustomerId" });
            DropTable("dbo.ShippingAddress");
        }
    }
}
