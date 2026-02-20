using Identity.Models;
using System.Threading.Tasks;
using Duende.IdentityServer.Stores;
using System.Linq;
using Duende.IdentityServer.Models;
using MongoDbHelper;

namespace Identity.Store
{ 
    public class CustomClientStore : IClientStore
    {
        private readonly IMongoRepository _repository;

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var mongoClient = await _repository.FindOneAsync<Clients>(c => c.ClientId == clientId);
            if (mongoClient == null) return null;

            return new Client
            {
                ClientId = mongoClient.ClientId,
                ClientName = mongoClient.ClientName,
                AllowedGrantTypes = mongoClient.AllowedGrantTypes.ToList(),
                AllowedScopes = mongoClient.AllowedScopes.ToList(),
                ClientSecrets = mongoClient.ClientSecrets.Select(cs => new Secret(cs.Value, cs.Description, cs.Expiration)).ToList(),
                AllowedCorsOrigins = mongoClient.AllowedCorsOrigins
            };
        }
    }
}
