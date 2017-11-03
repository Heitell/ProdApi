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
        BaseProduct[] products = new BaseProduct[]
        {
            new BaseProduct { Id = 1, Name = "Помидор" },
            new BaseProduct { Id = 2, Name = "Огурец" },
            new BaseProduct { Id = 3, Name = "Перец" }
        };

        public IEnumerable<BaseProduct> GetAllProducts()
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
