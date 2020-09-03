namespace _09_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Address_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Product_Id1" });
            DropColumn("dbo.Orders", "Product_Id");
            RenameColumn(table: "dbo.Orders", name: "Product_Id1", newName: "Product_Id");
            DropColumn("dbo.Products", "Address_Id");
            DropColumn("dbo.Products", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            AddColumn("dbo.Products", "Address_Id", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "Product_Id", newName: "Product_Id1");
            AddColumn("dbo.Orders", "Product_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Product_Id1");
            CreateIndex("dbo.Products", "Order_Id");
            CreateIndex("dbo.Products", "Address_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Products", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
