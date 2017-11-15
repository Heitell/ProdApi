namespace ProdApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Auth1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavoriteProducts",
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
                "dbo.MeasuresDiaryLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Value = c.Single(nullable: false),
                        IdentityUser_Id = c.Int(),
                        Measure_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .ForeignKey("dbo.Measures", t => t.Measure_Id)
                .Index(t => t.IdentityUser_Id)
                .Index(t => t.Measure_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeasuresDiaryLines", "Measure_Id", "dbo.Measures");
            DropForeignKey("dbo.MeasuresDiaryLines", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.FavoriteProducts", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.FavoriteProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.MeasuresDiaryLines", new[] { "Measure_Id" });
            DropIndex("dbo.MeasuresDiaryLines", new[] { "IdentityUser_Id" });
            DropIndex("dbo.FavoriteProducts", new[] { "IdentityUser_Id" });
            DropIndex("dbo.FavoriteProducts", new[] { "Product_Id" });
            DropTable("dbo.MeasuresDiaryLines");
            DropTable("dbo.FavoriteProducts");
        }
    }
}
