using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INAB.Models.DataModels
{
    public class Household
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int Name { get; set; }
    }
}