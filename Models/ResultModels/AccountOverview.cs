using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INAB.Models.ResultModels
{
    public class AccountOverview
    {
        public string AccountName { get; set; }
        public string OwnerName { get; set; }
        public Decimal Balance { get; set; }
        public Decimal ReconciledBalance { get; set; }
        public int AccountId { get; set; }
    }
}
