using ProdApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProdApi.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        //BaseProduct[] products = new BaseProduct[]
        //{
        //    new BaseProduct { BaseProductId = 1, Name = "Помидор" },
        //    new BaseProduct { BaseProductId = 2, Name = "Огурец" },
        //    new BaseProduct { BaseProductId = 3, Name = "Перец" }
        //};
        ProductContext db = new ProductContext();

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(db.BaseProducts);
        }

        //public IEnumerable<BaseProduct> GetAllProducts()
        //{
        //    return db.BaseProducts;
        //}

        [Authorize]
        [Route("")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = db.BaseProducts.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Authorize]
        [Route("GetDiaryLinesByDate")]
        public IHttpActionResult GetDiaryLinesByDate(string date)
        {
            DateTime dateTime = DateTime.ParseExact( date, "ddMMyyyy", null);
            var product = db.FoodDiaryLines.Where((p) => p.DateTime == dateTime);

            Summary dailySum = new Summary(product);
            return Ok(dailySum);
        }
    }
}
