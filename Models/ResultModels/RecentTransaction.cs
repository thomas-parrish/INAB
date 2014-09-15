using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INAB.Models.ResultModels
{
    public class RecentTransaction
    {
        public string AccountName {get; set;}
        public DateTimeOffset Date { get; set; }
        public string Category { get; set; }
        public bool IsDeposit {get; set;}
        public Decimal Amount {get; set;}
        public bool IsReconciled {get; set;}
        public int TransactionId { get; set; }
    }
}
