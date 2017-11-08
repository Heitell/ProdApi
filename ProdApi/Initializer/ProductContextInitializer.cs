using ProdApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProdApi.Initializer
{
    public class ProductContextInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            BaseProduct p1 = new BaseProduct { Name = "Треска" };
            BaseProduct p2 = new BaseProduct { Name = "Индейка" };            

            db.BaseProducts.Add(p1);
            db.BaseProducts.Add(p2);
            db.SaveChanges();
        }
    }
}