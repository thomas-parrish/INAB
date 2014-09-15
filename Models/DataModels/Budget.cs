using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INAB.Models.DataModels
{
    public class Budget
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int HouseholdId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public int? Month { get; set; }
    }
}