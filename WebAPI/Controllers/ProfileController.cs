using INAB.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Insight.Database;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using INAB.Models.ResultModels;
using INAB.Models.DataModels;

namespace INAB.WebAPI.Controllers
{
    [RoutePrefix("api/Profile")]
    public class ProfileController : ApiController
    {
        private IProfileAccess db;
        private ApplicationUserManager um;
        // GET: api/Dashboard

        public ProfileController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>().As<IProfileAccess>();
            um = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }
        
        [Route("GetProfileData")]
        // GET: api/Profile
        public async Task<ProfileData> GetProfileData()
        {
            var user = await um.FindByNameAsync(HttpContext.Current.User.Identity.Name);
            return new ProfileData(await db.SelectUserAsync(user.Id));
        }

        // GET: api/Profile/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Profile
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Profile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Profile/5
        public void Delete(int id)
        {
        }
    }
}
