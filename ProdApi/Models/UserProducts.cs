using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdApi.Models
{
    public class UserProducts
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Key]
        [Column(Order = 2)]
        public int UserId { get; set; }

        public Users User { get; set; }
    }
}