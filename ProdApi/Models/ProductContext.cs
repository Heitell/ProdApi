using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProdApi.Models
{
    public class ProductContext : DbContext
    {
        

        public DbSet<BaseProduct> BaseProducts { get; set; }
        public DbSet<ProductPart> ProductParts { get; set; }
        public DbSet<CookingType> CookingTypes { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}