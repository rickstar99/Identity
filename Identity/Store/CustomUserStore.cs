using Identity.Interface;
using Identity.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Store
{
    public class CustomUserStore : IUserStore
    {
        public User AutoProvisionUser(string provider, string userId, List<Claim> claims)
        {
            throw new System.NotImplementedException();
        }

        public void ChangePassword(string username, string password, bool isStaff)
        {
            throw new System.NotImplementedException();
        }

        public User FindByExternalProvider(string provider, string userId, string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindBySubjectId(string subjectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindByUsername(string username)
        {
            throw new System.NotImplementedException();
        }

        public void MarkEmailAsVerified(string username)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateCredentials(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
