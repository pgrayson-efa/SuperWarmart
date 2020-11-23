namespace SuperWarmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "HomeCity", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "HomeCity", c => c.String());
        }
    }
}
