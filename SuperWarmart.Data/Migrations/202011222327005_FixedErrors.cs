namespace SuperWarmart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedErrors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "HomeZipcodeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "HomeZipcodeId");
        }
    }
}
