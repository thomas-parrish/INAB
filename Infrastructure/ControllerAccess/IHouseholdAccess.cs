using INAB.Models.DataModels;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace INAB.Infrastructure.DataAccess
{
    public interface IHouseholdAccess
    {
        Task<int> InsertInvite(Invite newInvite);

        Task<List<AppUser>> GetHouseholdMembers(int HouseholdId);
    }
}