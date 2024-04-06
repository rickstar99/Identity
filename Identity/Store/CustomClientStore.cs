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
using Microsoft.Extensions.Logging;
using System.Linq;
using Duende.IdentityServer.Models;
using Duende.IdentityServer;

namespace Identity.Store
{ 
    public class CustomClientStore : IClientStore
    {
        private readonly MongoDbSettings mdbSettings;
        private readonly IConfiguration _config;

        public CustomClientStore(IConfiguration config)
        {
            _config = config;
            mdbSettings = new MongoDbSettings();
            _config.GetSection("MongoDbSettings").Bind(mdbSettings);
        }

        public Task<Duende.IdentityServer.Models.Client> FindClientByIdAsync(string clientId)
        {
            var _x = "ailacs".Sha256();
            var repo = new MongoRepository<Models.Client>(mdbSettings);
            var mongoClient = repo.FindOne(c => c.ClientId == clientId);
            if (mongoClient == null) return null;

            var client = new Duende.IdentityServer.Models.Client
            {
                ClientId = mongoClient.ClientId,
                ClientName = mongoClient.ClientName,
                AllowedGrantTypes = mongoClient.AllowedGrantTypes.ToList(),
                AllowedScopes = mongoClient.AllowedScopes.ToList(),
                ClientSecrets = mongoClient.ClientSecrets.Select(cs => new Secret(cs.Value, cs.Description, cs.Expiration)).ToList(),
                AllowedCorsOrigins = mongoClient.AllowedCorsOrigins
                // ... map other properties as needed
            };
            return Task.FromResult(client);
        }
    }
}
