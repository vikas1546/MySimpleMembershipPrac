namespace SimpleMembershipPrac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedthetestpropertytocategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "test1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "test1");
        }
    }
}
