namespace ProdApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApiDb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CookingTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "CookingType_Id", c => c.Int());
            AddColumn("dbo.Products", "ProductPart_Id", c => c.Int());
            CreateIndex("dbo.Products", "CookingType_Id");
            CreateIndex("dbo.Products", "ProductPart_Id");
            AddForeignKey("dbo.Products", "CookingType_Id", "dbo.CookingTypes", "Id");
            AddForeignKey("dbo.Products", "ProductPart_Id", "dbo.ProductParts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductPart_Id", "dbo.ProductParts");
            DropForeignKey("dbo.Products", "CookingType_Id", "dbo.CookingTypes");
            DropIndex("dbo.Products", new[] { "ProductPart_Id" });
            DropIndex("dbo.Products", new[] { "CookingType_Id" });
            DropColumn("dbo.Products", "ProductPart_Id");
            DropColumn("dbo.Products", "CookingType_Id");
            DropTable("dbo.ProductParts");
            DropTable("dbo.CookingTypes");
        }
    }
}
