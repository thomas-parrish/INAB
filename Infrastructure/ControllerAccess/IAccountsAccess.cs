using INAB.Models.DataModels;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using INAB.Models.ResultModels;

namespace INAB.Infrastructure.DataAccess
{
    public interface IAccountsAccess
    {
        //For Overview page
        Task<List<RecentTransaction>> GetRecentTransactionsForAccount(int AccountId, int? NumTransactions, int? HowRecent);
        Task<List<AccountOverview>> GetAccountOverviews(int HouseholdId);

        Task<int> InsertAccountAsync(NewAccount account);


        //For Details page
        Task<Account> SelectAccountAsync(int AccountId);
        Task ReconcileAccount(int AccountId);
        Task DeleteAccountAsync(int AccountId);
        Task UpdateAccountAsync(Account account);

        //Stored Proc
        Task<Decimal> GetAccountBalance(int AccountId);
        Task<Decimal> GetReconciledAccountBalance(int AccountId);
    }
}