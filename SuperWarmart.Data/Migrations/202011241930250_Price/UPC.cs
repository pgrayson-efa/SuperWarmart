namespace SuperWarmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceUPC : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InventoryItem", "UPC", c => c.String(nullable: false));
            AlterColumn("dbo.InventoryItem", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InventoryItem", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.InventoryItem", "UPC", c => c.Int(nullable: false));
        }
    }
}
