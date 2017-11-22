using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProdApi.Initializer;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProdApi.Models
{
    // был наследником DbContext
    public class ProductContext : IdentityDbContext<ProdApi.Models.Users>
    {
        static ProductContext()
        {
            Database.SetInitializer<ProductContext>(new ProductContextInitializer());
        }

        public ProductContext() : base("ProductsApiDB")
        { }
           
        

        public DbSet<Product> Products { get; set; }
        public DbSet<BaseProduct> BaseProducts { get; set; }
        public DbSet<CookingType> CookingTypes { get; set; }
        public DbSet<ProductPart> ProductParts { get; set; }
        public override IDbSet<Users> Users { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<UserPermissionRoles> UserPermissionRoles { get; set; }
        public DbSet<UserProducts> UserProducts { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<FoodDiaryLines> FoodDiaryLines { get; set; }
        public DbSet<MeasuresDiaryLines> MeasuresDiaryLines { get; set; }
        public DbSet<FavoriteProducts> FavoriteProducts { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}