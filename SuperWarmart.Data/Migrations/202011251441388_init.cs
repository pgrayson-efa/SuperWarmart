namespace SuperWarmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        CompanyName = c.String(),
                        HomeAddress = c.String(nullable: false),
                        HomeCity = c.String(nullable: false),
                        HomeStateId = c.Int(nullable: false),
                        HomeZipcodeId = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
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
                "dbo.InventoryItem",
                c => new
                    {
                        InventoryItemId = c.Int(nullable: false, identity: true),
                        UPC = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        StockNumber = c.String(nullable: false),
                        ItemName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
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
                        OrderStatusId = c.Int(nullable: false),
                        Notes = c.String(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        TotalCost = c.Double(nullable: false),
                        DateOfOrder = c.DateTime(nullable: false),
                        DateShipped = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(nullable: false),
                        Abbr = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Zipcode",
                c => new
                    {
                        ZipcodeId = c.Int(nullable: false, identity: true),
                        VerifiedZipcode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ZipcodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ShippingAddress", "CustomerId", "dbo.Customer");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ShippingAddress", new[] { "CustomerId" });
            DropTable("dbo.Zipcode");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.State");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Order");
            DropTable("dbo.OrderLineItem");
            DropTable("dbo.InventoryItem");
            DropTable("dbo.ShippingAddress");
            DropTable("dbo.Customer");
        }
    }
}
