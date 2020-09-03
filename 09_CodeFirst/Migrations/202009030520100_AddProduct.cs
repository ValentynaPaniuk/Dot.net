namespace _09_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Address_Id", c => c.Int());
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            CreateIndex("dbo.Products", "Address_Id");
            CreateIndex("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Products", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Products", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Products", new[] { "Address_Id" });
            DropColumn("dbo.Products", "Order_Id");
            DropColumn("dbo.Products", "Address_Id");
        }
    }
}
