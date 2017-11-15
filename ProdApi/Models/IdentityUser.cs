using froko.Owin.Security.Jwt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdApi.Models
{
    public class IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Password Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Permissions> Permissions { get; set; }
        public ICollection<UserProducts> UserProducts { get; set; }
        public ICollection<FoodDiaryLines> FoodDiaryLines { get; set; }
        public ICollection<FavoriteProducts> FavoriteProducts { get; set; }
        public ICollection<MeasuresDiaryLines> MeasuresDiaryLines { get; set; }
    }
}