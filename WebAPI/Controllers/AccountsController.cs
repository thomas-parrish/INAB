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
    [RoutePrefix("api/Accounts")]
    public class AccountsController : ApiController
    {
        private IAccountsAccess db;
        private ApplicationUserManager um;
        // GET: api/Dashboard

        public AccountsController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>().As<IAccountsAccess>();
            um = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }
        
        [Authorize]
        [Route("GetRecentTransactionsForAccount")]
        public async Task<List<RecentTransaction>> GetRecentTransactionsForAccount(int AccountId)
        {
            return await db.GetRecentTransactionsForAccount(AccountId,5,14);
        }

        [Authorize]
        [Route("GetAccountOverviews")]
        public async Task<List<AccountOverview>> GetAccountOverviews()
        {
            var username = HttpContext.Current.User.Identity.Name;
            var user = await um.FindByNameAsync(username);
            return await db.GetAccountOverviews(user.HouseholdId);
        }

        [Authorize]
        [Route("PostNewAccount")]
        public async Task<int> PostNewAccount(NewAccount entry)
        {
            var username = HttpContext.Current.User.Identity.Name;
            var user = await um.FindByNameAsync(username);
            entry.OwnerId = user.Id;

            return await db.InsertAccountAsync(entry);
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
