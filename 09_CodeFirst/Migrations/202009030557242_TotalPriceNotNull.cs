namespace _09_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalPriceNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Double());
        }
    }
}
