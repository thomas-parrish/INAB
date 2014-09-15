using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INAB.Models.DataModels
{
    public class Transaction
    {
        public int id { get; set; }
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public int AuthorizedBy { get; set; }
        public Decimal Amount { get; set; }
        public bool IsReconciled { get; set; }
        public string Description { get; set; }
        public bool IsDeposit { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public Decimal? AmountReconciled { get; set; }
    }
}