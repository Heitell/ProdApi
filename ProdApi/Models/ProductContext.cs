using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProdApi.Initializer;

namespace ProdApi.Models
{
    public class ProductContext : DbContext
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
    }
}