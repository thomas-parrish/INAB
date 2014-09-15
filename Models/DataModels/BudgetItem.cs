using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INAB.Models.DataModels
{
    public class BudgetItem
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BudgetId { get; set; }
        public bool IsIncome { get; set; }
    }
}