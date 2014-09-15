using INAB.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INAB.Models.ResultModels
{
    public class ProfileData
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }

        public ProfileData() {}
        public ProfileData(AppUser user)
        {
            Name = user.Name;
            Username = user.UserName;
            Email = user.Email;
            Id = user.Id;
        }
    }
}
