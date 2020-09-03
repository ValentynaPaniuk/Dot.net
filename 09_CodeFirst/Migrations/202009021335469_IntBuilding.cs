namespace _09_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntBuilding : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Builder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Builder", c => c.String());
        }
    }
}
