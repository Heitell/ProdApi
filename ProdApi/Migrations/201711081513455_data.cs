namespace ProdApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseProducts",
                c => new
                    {
                        BaseProductId = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BaseProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Protein = c.Single(nullable: false),
                        Fat = c.Single(nullable: false),
                        Carbohydrates = c.Single(nullable: false),
                        Callories = c.Int(nullable: false),
                        BaseProduct_BaseProductId = c.Byte(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.BaseProducts", t => t.BaseProduct_BaseProductId)
                .Index(t => t.BaseProduct_BaseProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "BaseProduct_BaseProductId", "dbo.BaseProducts");
            DropIndex("dbo.Products", new[] { "BaseProduct_BaseProductId" });
            DropTable("dbo.Products");
            DropTable("dbo.BaseProducts");
        }
    }
}
