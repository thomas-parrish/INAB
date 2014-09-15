using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using INAB.Models.DataModels;
using INAB.Infrastructure;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;
using Microsoft.Owin;
using Insight.Database;
using System.Web.Http;
using INAB.Models.ViewModels;


namespace INAB.WebAPI.Controllers
{
    [RoutePrefix("WebAPI")]
    public class UserAccountController : ApiController
    {
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> register(RegisterViewModel registerInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUser = new INAB.Models.DataModels.AppUser(registerInfo);
            var userManager =  HttpContext.Current.GetOwinContext().Get<INAB.ApplicationUserManager>();

            var result = await userManager.CreateAsync(newUser, registerInfo.Password);

            return result.GetErrorResult(this);
        }

    }

    public static class ApiExtensions
    {
        public static IHttpActionResult GetErrorResult(this IdentityResult result, ApiController controller)
        {
            if (result == null)
            {
                return new System.Web.Http.Results.InternalServerErrorResult(controller);
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        controller.ModelState.AddModelError("", error);
                    }
                }

                if (controller.ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return new System.Web.Http.Results.BadRequestResult(controller);
                }

                return new System.Web.Http.Results.BadRequestResult(controller);
            }

            return new System.Web.Http.Results.OkResult(controller);
        }
    }
}
