using Identity.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Duende.IdentityServer.Stores;
using Identity.Repository;
using Identity.MongoDb;
using Identity.Interface;
using Microsoft.Extensions.Configuration;

namespace Identity.Store
{ 
    public class CustomUserStore : IClientStore
    {
        private readonly MongoDbSettings mdbSettings;
        private readonly IConfiguration _config;

        public CustomUserStore(IConfiguration config)
        {
            _config = config;
            mdbSettings = new MongoDbSettings();
            _config.GetSection("MongoDbSettings").Bind(mdbSettings);
        }

        public Task<Duende.IdentityServer.Models.Client> FindClientByIdAsync(string clientId)
        {
            var repo = new MongoRepository<Models.Client>(mdbSettings);

            var client = repo.FindOne(c => c.ClientId == clientId);

            return Task.FromResult((Duende.IdentityServer.Models.Client)client);
        }
    }
}
