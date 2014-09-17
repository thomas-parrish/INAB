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
    [RoutePrefix("api/Household")]
    public class HouseholdController : ApiController
    {
        private IHouseholdAccess db;
        private ApplicationUserManager um;
        // GET: api/Dashboard

        public HouseholdController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>().As<IHouseholdAccess>();
            um = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }
        
        [Route("GetProfileData")]
        // GET: api/Profile
        public async Task<List<ProfileData>> GetProfileData()
        {
            var currentUser = await um.FindByNameAsync(HttpContext.Current.User.Identity.Name);
            var householdMembers = await db.GetHouseholdMembers(currentUser.HouseholdId);

            var householdMemberProfiles = new List<ProfileData>();

            foreach(var member in householdMembers)
                householdMemberProfiles.Add(new ProfileData(member));

            return householdMemberProfiles;
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
