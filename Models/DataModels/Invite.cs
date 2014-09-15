using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INAB.Models.DataModels
{
    public class Invite
    {
        public int Id { get; set; }
        public int InvitedByUser { get; set; }
        public int? InvitedExistingUser { get; set; }
        public string InvitedNewUser { get; set; }
        public int HousholdId { get; set; }
        public bool Accepted { get; set; }
        public bool Seen { get; set; }
    }
}