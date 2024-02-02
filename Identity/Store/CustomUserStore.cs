using Duende.IdentityServer.Models;
using Identity.Interface;
using Identity.Models;
using Identity.MongoDb;
using Identity.Repository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Store
{
    public class CustomUserStore : IUserStore
    { 
        private readonly MongoDbSettings mdbSettings;
        private readonly IConfiguration _config;

    public CustomUserStore(IConfiguration config)
    {
        _config = config;
        mdbSettings = new MongoDbSettings();
        _config.GetSection("MongoDbSettings").Bind(mdbSettings);
    }

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
            var repo = new MongoRepository<User>(mdbSettings);

            var user = repo.FindOne(u => u.Username == username && u.Password == password.Sha256());
            return user != null;
        }
    }
}
