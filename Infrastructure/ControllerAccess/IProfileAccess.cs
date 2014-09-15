using INAB.Models.DataModels;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace INAB.Infrastructure.DataAccess
{
    public interface IProfileAccess
    {
        [Sql(Schema = "Security")]
        Task UpdateUserAsync(AppUser user);

        [Sql(Schema = "Security")]
        Task<AppUser> SelectUserAsync(int id);
    }
}