using ProdApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProdApi.Controllers
{
    public class ProductController : ApiController
    {
        //BaseProduct[] products = new BaseProduct[]
        //{
        //    new BaseProduct { BaseProductId = 1, Name = "Помидор" },
        //    new BaseProduct { BaseProductId = 2, Name = "Огурец" },
        //    new BaseProduct { BaseProductId = 3, Name = "Перец" }
        //};
        ProductContext db = new ProductContext();
        

        public IEnumerable<BaseProduct> GetAllProducts()
        {
            return db.BaseProducts;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = db.BaseProducts.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
