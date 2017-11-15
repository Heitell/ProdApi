namespace ProdApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Auth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(),
                        IdentityUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.FoodDiaryLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        BaseProductName = c.String(),
                        ProductPartName = c.String(),
                        CookingTypeName = c.String(),
                        Weight = c.Int(nullable: false),
                        Protein = c.Single(nullable: false),
                        Fat = c.Single(nullable: false),
                        Carbohydrates = c.Single(nullable: false),
                        Calories = c.Single(nullable: false),
                        IdentityUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProducts", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.FoodDiaryLines", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.UserProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.FoodDiaryLines", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserProducts", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserProducts", new[] { "Product_Id" });
            DropTable("dbo.FoodDiaryLines");
            DropTable("dbo.UserProducts");
        }
    }
}
