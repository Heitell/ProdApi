using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProdApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProdApi.Authorization
{
    public class AuthRepository : IDisposable
    {
        private ProductContext _ctx;

        private UserManager<Models.Users> _userManager;

        public AuthRepository()
        {
            _ctx = new ProductContext();
            _userManager = new UserManager<Models.Users>(new UserStore<Models.Users>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(Models.Users userModel)
        {
            Models.Users user = new Models.Users
            {
                UserName = userModel.UserName,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            IdentityResult result = null;
            try
            {
                result = await _userManager.CreateAsync(user, userModel.Password);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            

            return result;
        }

        public async Task<Models.Users> FindUser(string userName, string password)
        {
            Models.Users user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}