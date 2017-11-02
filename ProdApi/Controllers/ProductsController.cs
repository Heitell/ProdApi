using ProdApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProdApi.Controllers
{
    public class ProductsController : ApiController
    {
        BaseProducts[] products = new BaseProducts[]
        {
            new BaseProducts { Id = 1, Name = "Помидор" },
            new BaseProducts { Id = 2, Name = "Огурец" },
            new BaseProducts { Id = 3, Name = "Перец" }
        };

        public IEnumerable<BaseProducts> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
