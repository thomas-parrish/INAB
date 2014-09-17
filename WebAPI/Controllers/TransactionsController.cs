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
    [RoutePrefix("api/Transactions")]
    public class TransactionsController : ApiController
    {
        private ITransactionsAccess db;
        private ApplicationUserManager um;
        // GET: api/Dashboard

        public TransactionsController()
        {
            db = HttpContext.Current.GetOwinContext().Get<SqlConnection>().As<ITransactionsAccess>();
            um = HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>();
        }
        
        [Authorize]
        [Route("GetAllTransactions")]
        public async Task<List<Transaction>> GetAllTransactions(int AccountId)
        {
            return await db.GetAllTransactions(AccountId);
        }

        [Authorize]
        [Route("GetCategories")]
        public async Task<Dictionary<int, Object>> GetCategories()
        {
            var categoryArray = await db.GetCategories();
            //Not sure if it's ok to do this here, or if I should do this in javascript
            Dictionary<int, Object> categoryDict = new Dictionary<int, object>();

            foreach(var category in categoryArray)
            {
                categoryDict.Add(category.Id, new { name = category.Name, description = category.Description });
            }

            return categoryDict;
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
