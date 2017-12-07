using Microsoft.AspNet.Identity;
using ProdApi.Authorization;
using ProdApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ProdApi.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;

        public AccountController()
        {
            _repo = new AuthRepository();            
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(Users userModel)
        {          
            
            if (!ModelState.IsValid)
            {
                return Content<Reply>(HttpStatusCode.BadRequest, new Reply(ErrorCode.FieldValidationError, "Ошибка при проверке полей формы.", FormReplyMessage()));                
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            Reply errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return Content<Reply>(HttpStatusCode.BadRequest, errorResult);                
            }

            return Content<Reply>(HttpStatusCode.OK, new Reply(ErrorCode.OK, "Запрос выполнен.", FormReplyMessage()));           
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private Reply GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return new Reply(ErrorCode.UspecifyedError, "Ошибка севера.", FormReplyMessage());
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }                    
                }                

                return new Reply(ErrorCode.UspecifyedError, "Ошибка севера.", FormReplyMessage()); ;
            }

            return null;
        }

        private List<ErrorDetails> FormReplyMessage()
        {
            //Dictionary<string, string> temp = new Dictionary<string, string>();
            List<ErrorDetails> temp = new List<ErrorDetails>();
            IEnumerable<string> tempkey = ModelState.Keys.SelectMany(key => this.ModelState[key].Errors.Select(x => key));

            int i = 0;
            string tempItemName = string.Empty;
            foreach (var item in tempkey)
            {
                if (item != tempItemName)
                {
                    tempItemName = item;
                    IEnumerable<string> tempmessage = ModelState[item].Errors.Select(x => x.ErrorMessage);
                    foreach (var itemmessage in tempmessage)
                    {
                        temp.Add(new ErrorDetails(item, itemmessage));
                    }
                    i += tempmessage.Count();
                    if (i >= tempkey.Count())
                    {
                        break;
                    }
                }
                
            }
            return temp;
        }
    }
}
