using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdApi.Models
{
    public class FoodDiaryLines
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }
        public int ProductId { get; set; }
        public string BaseProductName { get; set; }
        public string ProductPartName { get; set; }
        public string CookingTypeName { get; set; }
        public int Weight { get; set;}
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public float Calories { get; set; }
    }
}