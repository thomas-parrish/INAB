using System.Collections.Generic;
using System.Threading.Tasks;
using INAB.Models.DataModels;
using Insight.Database;

namespace INAB.Infrastructure
{
    [Sql(Schema = "Security")]
    public interface IUserDataAccess
    {
        // auto procs
        Task<AppUser> SelectUserAsync(int id);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(AppUser user);
        Task InsertUserAsync(AppUser user);
        Task InsertUserLoginAsync(UserLogin userLogin);
        Task DeleteUserLoginAsync(UserLogin login);
        Task InsertUserClaimAsync(UserClaim claim);

        //Stored Procs

        Task<bool> AddUserToRoleAsync(int userId, string role);
        Task<bool> IsUserInRoleAsync(int userId, string role);
        Task<AppUser> FindUserByLoginAsync(string loginProvider, string providerKey);
        Task<IList<string>> GetRolesForUserAsync(int userId);
        Task RemoveUserFromRoleAsync(int userId, string role);
        Task RemoveUserClaimAsync(int userId, string claimType);

        //Inline SQL

        [Sql("select * from security.users where username = @userName")]
        Task<AppUser> FindUserByUserNameAsync(string userName);
              
        [Sql("select * from security.userlogins where userid = @userId")]
        Task<IList<UserLogin>> GetLoginsForUserAsync(int userId);
                  
        [Sql("select * from security.userclaims where userid = @userId")]
        Task<IList<UserClaim>> GetUserClaimsAsync(int userId);

        [Sql("select top 1 * from security.users where email = @email")]
        Task<AppUser> FindUserByEmailAsync(string email);

        //[Sql("select PhoneNumber from security.users where userid = @userId")]
        //Task<string> GetPhoneNumberForUserAsync(int userId);

        //[Sql("select PhoneNumberConfirmed from security.users where userid = @userId")]
        //Task<bool> GetPhoneNumberConfirmedForUserAsync(int userId);


    }
}