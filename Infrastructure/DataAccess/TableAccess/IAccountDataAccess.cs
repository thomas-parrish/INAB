using INAB.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace INAB.Infrastructure
{
    public interface IAccountDataAccess
    {
        //Autoprocs
        Task<Account> SelectAccountAsync(int AccountId);
        Task DeleteAccountAsync(int AccountId);
        Task UpdateAccountAsync(Account account);
        Task InsertAccountAsync(Account account);
        

        //Stored Procs
        Task<Decimal> GetAccountBalance(int AccountId);
        Task<Decimal> GetReconciledAccountBalance(int AccountId);
        Task ReconcileAccounts(int AccountId);
    }
}