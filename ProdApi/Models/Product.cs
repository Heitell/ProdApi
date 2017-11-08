using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdApi.Models
{
    public class Product
    {        
        public int ProductId { get; set; }          
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public int Callories { get; set; }       
        
    }
}