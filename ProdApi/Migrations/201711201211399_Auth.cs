namespace ProdApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Auth : DbMigration
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
                        IsApprove = c.Boolean(nullable: false),
                        BaseProduct_Id = c.Int(),
                        CookingType_Id = c.Int(),
                        ProductPart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseProducts", t => t.BaseProduct_Id)
                .ForeignKey("dbo.CookingTypes", t => t.CookingType_Id)
                .ForeignKey("dbo.ProductParts", t => t.ProductPart_Id)
                .Index(t => t.BaseProduct_Id)
                .Index(t => t.CookingType_Id)
                .Index(t => t.ProductPart_Id);
            
            CreateTable(
                "dbo.FavoriteProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.UserProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product_Id = c.Int(),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.CookingTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Measures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MeasuresDiaryLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Value = c.Single(nullable: false),
                        Measure_Id = c.Int(),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Measures", t => t.Measure_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.Measure_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserPermissionRoles_Id = c.Int(),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserPermissionRoles", t => t.UserPermissionRoles_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.UserPermissionRoles_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.ProductParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserPermissionRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Email = c.String(maxLength: 256),
                        PhoneNumber = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProducts", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permissions", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MeasuresDiaryLines", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FoodDiaryLines", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavoriteProducts", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Permissions", "UserPermissionRoles_Id", "dbo.UserPermissionRoles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Products", "ProductPart_Id", "dbo.ProductParts");
            DropForeignKey("dbo.MeasuresDiaryLines", "Measure_Id", "dbo.Measures");
            DropForeignKey("dbo.Products", "CookingType_Id", "dbo.CookingTypes");
            DropForeignKey("dbo.Products", "BaseProduct_Id", "dbo.BaseProducts");
            DropForeignKey("dbo.UserProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.FavoriteProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Permissions", new[] { "Users_Id" });
            DropIndex("dbo.Permissions", new[] { "UserPermissionRoles_Id" });
            DropIndex("dbo.MeasuresDiaryLines", new[] { "Users_Id" });
            DropIndex("dbo.MeasuresDiaryLines", new[] { "Measure_Id" });
            DropIndex("dbo.FoodDiaryLines", new[] { "Users_Id" });
            DropIndex("dbo.UserProducts", new[] { "Users_Id" });
            DropIndex("dbo.UserProducts", new[] { "Product_Id" });
            DropIndex("dbo.FavoriteProducts", new[] { "Users_Id" });
            DropIndex("dbo.FavoriteProducts", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "ProductPart_Id" });
            DropIndex("dbo.Products", new[] { "CookingType_Id" });
            DropIndex("dbo.Products", new[] { "BaseProduct_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserPermissionRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProductParts");
            DropTable("dbo.Permissions");
            DropTable("dbo.MeasuresDiaryLines");
            DropTable("dbo.Measures");
            DropTable("dbo.FoodDiaryLines");
            DropTable("dbo.CookingTypes");
            DropTable("dbo.UserProducts");
            DropTable("dbo.FavoriteProducts");
            DropTable("dbo.Products");
            DropTable("dbo.BaseProducts");
        }
    }
}
