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
    public interface ITransactionsAccess
    {
        //Autoprocs
        Task<int> InsertTransaction(Transaction entry);
        Task<Transaction> SelectTransaction(int id);
        Task<int> InsertCategory(Category entry);

        //Stored Procs


        //Inline
        [Sql("SELECT * FROM TRANSACTIONS WHERE AccountId = @AccountId")]
        Task<List<Transaction>> GetAllTransactions(int AccountId);

        [Sql("SELECT * FROM CATEGORIES")]
        Task<List<Category>> GetCategories();

    }
}