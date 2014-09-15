using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using INAB.Models.DataModels;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace INAB.Infrastructure
{
    public class InsightUserStore :
        IUserStore<AppUser,int>,
        IUserPhoneNumberStore<AppUser, int>,
        IUserPasswordStore<AppUser, int>, 
        IUserLoginStore<AppUser, int>,
        IUserRoleStore<AppUser, int>, 
        IUserClaimStore<AppUser, int>, 
        IUserEmailStore<AppUser, int>,
        IUserLockoutStore<AppUser, int>,
        IUserTwoFactorStore<AppUser, int>
    {
        private readonly IUserDataAccess _userData;

        public InsightUserStore(IUserDataAccess userData)
        {
            _userData = userData;
        }

        public void Dispose()
        {
            //I don't know how to do this?
        }

        public Task CreateAsync(AppUser user)
        {
            return _userData.InsertUserAsync(user);
        }

        public Task UpdateAsync(AppUser user)
        {
            return _userData.UpdateUserAsync(user);
        }

        public Task DeleteAsync(AppUser user)
        {
            return _userData.DeleteUserAsync(user.Id);
        }

        public async Task<AppUser> FindByIdAsync(int userId)
        {
            var user = await _userData.SelectUserAsync(userId);
            return user;
        }

        public Task<AppUser> FindByNameAsync(string userName)
        {
            return _userData.FindUserByUserNameAsync(userName);
        }

        public Task SetPhoneNumberAsync(AppUser user, string phoneNumber)
        {
            return Task.FromResult(user.PhoneNumber = phoneNumber);
        }

        public Task<string> GetPhoneNumberAsync(AppUser user)
        {
            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(AppUser user)
        {
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public Task SetPhoneNumberConfirmedAsync(AppUser user, bool confirmed)
        {

            return Task.FromResult(user.PhoneNumberConfirmed = confirmed);
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash)
        {
            return Task.FromResult(user.PasswordHash = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(AppUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(AppUser user)
        {
            return Task.FromResult(user.PasswordHash == null);
        }

        public Task AddLoginAsync(AppUser user, UserLoginInfo login)
        {
            return _userData.InsertUserLoginAsync(new UserLogin(){
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey,
                UserId = user.Id
            });
        }

        public Task RemoveLoginAsync(AppUser user, UserLoginInfo login)
        {
            return _userData.DeleteUserLoginAsync(new UserLogin()
            {
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey,
                UserId = user.Id
            });
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(AppUser user)
        {
            var logins = await _userData.GetLoginsForUserAsync(user.Id);

            return logins
                .Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey))
                .ToList();
        }

        public Task<AppUser> FindAsync(UserLoginInfo login)
        {
            return _userData.FindUserByLoginAsync(login.LoginProvider, login.ProviderKey);
        }

        public Task AddToRoleAsync(AppUser user, string roleName)
        {
            return _userData.AddUserToRoleAsync(user.Id, roleName);
        }

        public Task RemoveFromRoleAsync(AppUser user, string roleName)
        {
            return _userData.RemoveUserFromRoleAsync(user.Id, roleName);
        }

        public Task<IList<string>> GetRolesAsync(AppUser user)
        {
            return _userData.GetRolesForUserAsync(user.Id);
        }

        public Task<bool> IsInRoleAsync(AppUser user, string roleName)
        {
            return _userData.IsUserInRoleAsync(user.Id, roleName);
        }

        public async Task<IList<Claim>> GetClaimsAsync(AppUser user)
        {
            var userClaims = await _userData.GetUserClaimsAsync(user.Id);

            var claims = userClaims
                .Select(x => new Claim(x.ClaimType,x.ClaimValue))
                .ToList();

            // add other app specific claims
            if (user.Name != null)
                claims.Add(new Claim(ClaimTypes.GivenName, user.Name));

            return claims;
        }

        public async Task AddClaimAsync(AppUser user, Claim claim)
        {

            //?? why await? Why not userId?
            await _userData.InsertUserClaimAsync(new UserClaim(){
                //UserId = user.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            });
        }

        public async Task RemoveClaimAsync(AppUser user, Claim claim)
        {
            await _userData.RemoveUserClaimAsync(user.Id, claim.Type);
        }

        public Task SetEmailAsync(AppUser user, string email)
        {
            return Task.FromResult(user.Email = email);
        }

        public Task<string> GetEmailAsync(AppUser user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(AppUser user)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(AppUser user, bool confirmed)
        {
            return Task.FromResult(user.EmailConfirmed = confirmed);
        }

        public Task<AppUser> FindByEmailAsync(string email)
        {
            return _userData.FindUserByEmailAsync(email);
        }

        public Task<int> GetAccessFailedCountAsync(AppUser user)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(AppUser user)
        {
            return Task.FromResult(user.LockoutEnabled);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(AppUser user)
        {
            return Task.FromResult(user.LockoutEndDate);
        }

        public Task<int> IncrementAccessFailedCountAsync(AppUser user)
        {
            user.AccessFailedCount++;
            return Task.FromResult( user.AccessFailedCount );
        }

        public Task ResetAccessFailedCountAsync(AppUser user)
        {
            return Task.FromResult(user.AccessFailedCount = 0);
        }

        public Task SetLockoutEnabledAsync(AppUser user, bool enabled)
        {
            return Task.FromResult(user.LockoutEnabled = enabled);
        }

        public Task SetLockoutEndDateAsync(AppUser user, DateTimeOffset lockoutEnd)
        {
            return Task.FromResult(user.LockoutEndDate = lockoutEnd);
        }

        public Task<bool> GetTwoFactorEnabledAsync(AppUser user)
        {
            //Update user database tables
            return Task.FromResult(false);
        }

        public Task SetTwoFactorEnabledAsync(AppUser user, bool enabled)
        {
            //Update user database tables
            return Task.FromResult(false);
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}