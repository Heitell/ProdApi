namespace ProdApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ProdApi.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ProdApi.Models.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

    //    protected override void Seed(ProdApi.Models.ProductContext context)
    //    {
    //        context.BaseProducts.AddOrUpdate(new BaseProduct { BaseProductId = 1, Name = "Помидор" },
    //new BaseProduct { BaseProductId = 2, Name = "Огурец" });
            


    //    }
    }
}
