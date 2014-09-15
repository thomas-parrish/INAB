using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INAB.Models.ResultModels
{
    public class NewAccount
    {
        public string Name { get; set; }
        public Decimal InitialBalance { get; set; }
        public int OwnerId { get; set; }
    }
}