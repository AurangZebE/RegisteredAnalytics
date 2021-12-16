using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace RegisteredAnalytics.Models
{
    public class UserStoreService :
    IUserStore<AppUser>, IUserPasswordStore<AppUser>,
    IUserSecurityStampStore<AppUser>
    {
        public List<AppUser> AppUsers { get; private set; }

        public Task CreateAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppUser>> FindByNameAsync(string userName)
        {
            List<AppUser> task = 
            AppUsers.Where(apu => apu.UserName == userName).ToList();
            return task;
        }

        public Task<string> GetPasswordHashAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSecurityStampAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task SetSecurityStampAsync(AppUser user, string stamp)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        Task<AppUser> IUserStore<AppUser, string>.FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
