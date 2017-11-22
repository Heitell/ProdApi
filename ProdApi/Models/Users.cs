using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdApi.Models
{
    public class Users : Microsoft.AspNet.Identity.EntityFramework.IdentityUser
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public override string Id { get; set; }

        [Required]
        [Display(Name = "User name")]
        public override string UserName { get; set; }

        public override string Email { get; set; }
        public override string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Permissions> Permissions { get; set; }
        public ICollection<UserProducts> UserProducts { get; set; }
        public ICollection<FoodDiaryLines> FoodDiaryLines { get; set; }
        public ICollection<FavoriteProducts> FavoriteProducts { get; set; }
        public ICollection<MeasuresDiaryLines> MeasuresDiaryLines { get; set; }
    }
}