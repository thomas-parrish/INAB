using INAB.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using INAB.Providers;
using System.Configuration;
using System.Data.SqlClient;
using Insight.Database;
using INAB.Models.DataModels;
using System.Threading.Tasks;
using INAB.Models.ResultModels;

namespace INAB.WebAPI.Controllers
{
    [RoutePrefix("api/Dashboard")]
    public class DashboardController : ApiController
    {
        private IDashboardAccess db;
        private ApplicationUserManager um;
        // GET: api/Dashboard

        public DashboardController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>().As<IDashboardAccess>();
            um = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }
        
        [Authorize]
        [Route("GetRecentTransactions")]
        public async Task<List<RecentTransaction>> GetRecentTransactions()
        {
            var username = HttpContext.Current.User.Identity.Name;
            var user = await um.FindByNameAsync(username);
            return await db.GetRecentTransactions(user.HouseholdId);
        }

        [Authorize]
        [Route("GetAccountOverviews")]
        public async Task<List<AccountOverview>> GetAccountOverviews()
        {
            var username = HttpContext.Current.User.Identity.Name;
            var user = await um.FindByNameAsync(username);
            return await db.GetAccountOverviews(user.HouseholdId);
        }

        // POST: api/Dashboard
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Dashboard/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Dashboard/5
        public void Delete(int id)
        {
        }
    }
}
