﻿using INAB.Models.DataModels;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using INAB.Models.ResultModels;

namespace INAB.Infrastructure.DataAccess
{
    public interface IDashboardAccess
    {
        Task<List<RecentTransaction>> GetRecentTransactions(int HouseholdId, int? NumTransactions, int? HowRecent);
        Task<List<AccountOverview>> GetAccountOverviews(int HouseholdId);
    }
}