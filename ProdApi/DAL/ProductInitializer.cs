using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProdApi.DAL
{
    public class ProductInitializer : DropCreateDatabaseIfModelChanges<Models.ProductContext>
    {
        protected override void Seed(Models.ProductContext context)
        {
            var baseProd = new List<Models.BaseProduct>
            {
                new Models.BaseProduct { Name = "Помидор" },
                new Models.BaseProduct { Name = "Огурец" },
                new Models.BaseProduct { Name = "Перец" },
                new Models.BaseProduct { Name = "Капуста" },
                new Models.BaseProduct { Name = "Свекла" },
                new Models.BaseProduct { Name = "Горох" },
                new Models.BaseProduct { Name = "Пшеничная мука" },
                new Models.BaseProduct { Name = "Куриное Яйцо" }
            };
            
            baseProd.ForEach(s => context.BaseProducts.Add(s));
            context.SaveChanges();

            var cookingType = new List<Models.CookingType>
            {
                new Models.CookingType { Name = "Варка" },
                new Models.CookingType { Name = "Жарка" },
                new Models.CookingType { Name = "Тушение" },
                new Models.CookingType { Name = "На пару" },
                new Models.CookingType { Name = "Запекание" },
                new Models.CookingType { Name = "Гриль" },
                new Models.CookingType { Name = "Сырое" }
            };
            cookingType.ForEach(s => context.CookingTypes.Add(s));
            context.SaveChanges();            
        }
    }
}