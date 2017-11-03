using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdApi.Models
{
    public class BaseProduct
    {
        [Required]
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Product Product { get; set; }
    }
}