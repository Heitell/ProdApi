namespace ProdApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApiDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Protein = c.Single(nullable: false),
                        Fat = c.Single(nullable: false),
                        Carbohydrates = c.Single(nullable: false),
                        Callories = c.Int(nullable: false),
                        BaseProduct_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseProducts", t => t.BaseProduct_Id)
                .Index(t => t.BaseProduct_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "BaseProduct_Id", "dbo.BaseProducts");
            DropIndex("dbo.Products", new[] { "BaseProduct_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.BaseProducts");
        }
    }
}
