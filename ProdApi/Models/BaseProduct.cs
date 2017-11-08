using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdApi.Models
{
    public class BaseProduct
    {        
        public byte BaseProductId { get; set; }        
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}