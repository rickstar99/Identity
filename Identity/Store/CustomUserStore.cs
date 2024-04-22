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


        public Users ValidateCredentials(string username, string password)
        {
            var repo = new MongoRepository<Users>(mdbSettings);

            return repo.FindOne(u => u.Username == username && u.Password == password.Sha256());
        }
    }
}
