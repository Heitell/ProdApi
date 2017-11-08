using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdApi.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  
        public string Name { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public int Callories { get; set; }       
        
    }
}