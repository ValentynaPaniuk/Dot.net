namespace _09_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        Builder = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manufactures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameManufacture = c.String(),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameProduct = c.String(),
                        Price = c.Double(nullable: false),
                        IsLegal = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                        Manufacture_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Manufactures", t => t.Manufacture_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Manufacture_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCategory = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Address_Id = c.Int(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameClient = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Orders", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Products", "Manufacture_Id", "dbo.Manufactures");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Manufactures", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropIndex("dbo.Orders", new[] { "Address_Id" });
            DropIndex("dbo.Products", new[] { "Manufacture_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Manufactures", new[] { "Address_Id" });
            DropTable("dbo.Clients");
            DropTable("dbo.Orders");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Manufactures");
            DropTable("dbo.Addresses");
        }
    }
}
