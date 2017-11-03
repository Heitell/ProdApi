namespace ProdApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseProducts",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        Products_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Products_Id)
                .Index(t => t.Products_Id);
            
            CreateTable(
                "dbo.CookingType",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        Products_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Products_Id)
                .Index(t => t.Products_Id);
            
            CreateTable(
                "dbo.ProductParts",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        Products_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Products_Id)
                .Index(t => t.Products_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Protein = c.Single(nullable: false),
                        Fat = c.Single(nullable: false),
                        Carbohydrates = c.Single(nullable: false),
                        Callories = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductParts", "Products_Id", "dbo.Products");
            DropForeignKey("dbo.CookingType", "Products_Id", "dbo.Products");
            DropForeignKey("dbo.BaseProducts", "Products_Id", "dbo.Products");
            DropIndex("dbo.ProductParts", new[] { "Products_Id" });
            DropIndex("dbo.CookingType", new[] { "Products_Id" });
            DropIndex("dbo.BaseProducts", new[] { "Products_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductParts");
            DropTable("dbo.CookingType");
            DropTable("dbo.BaseProducts");
        }
    }
}
