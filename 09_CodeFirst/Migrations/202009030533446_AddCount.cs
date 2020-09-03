namespace _09_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Product_Id", c => c.Int());
            AddColumn("dbo.Orders", "Product_Id1", c => c.Int());
            CreateIndex("dbo.Orders", "Product_Id");
            CreateIndex("dbo.Orders", "Product_Id1");
            AddForeignKey("dbo.Orders", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Orders", "Product_Id1", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Product_Id1", "dbo.Products");
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Product_Id1" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropColumn("dbo.Orders", "Product_Id1");
            DropColumn("dbo.Orders", "Product_Id");
            DropColumn("dbo.Orders", "Count");
        }
    }
}
