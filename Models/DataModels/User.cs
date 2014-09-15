﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using INAB.Models.ViewModels;

namespace INAB.Models.DataModels
{
    public class AppUser : IUser<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLockedOut { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTimeOffset LockoutEndDate { get; set; }
        public int AccessFailedCount { get; set; }
        public bool LockoutEnabled { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public int HouseholdId { get; set; }

        public AppUser()
        {

        }

        public AppUser(RegisterViewModel registeration) : this()
        {
            UserName = registeration.Username;
            Name = registeration.Name;
            Email = registeration.Email;
            IsDeleted = false;
            IsLockedOut = false;
            LockoutEnabled = false;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser,int> manager, string authType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}