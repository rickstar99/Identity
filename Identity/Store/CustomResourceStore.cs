using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;
using Identity.MongoDb;
using Identity.Repository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Store
{
    public class CustomResourceStore : IResourceStore
    {

        private readonly MongoDbSettings mdbSettings;
        private readonly IConfiguration _config;

        public CustomResourceStore(IConfiguration config)
        {
            _config = config;
            mdbSettings = new MongoDbSettings();
            _config.GetSection("MongoDbSettings").Bind(mdbSettings);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var repo = new MongoRepository<Models.IdentityResource>(mdbSettings);

            var list = repo.FilterBy(r => r.Enabled).ToList();

            var apiSResources = list.Select(resource => new ApiResource
            {
                Name = resource.Name,
                Enabled  = true,
                DisplayName = resource.DisplayName,
                Description = resource.Description,
            });

            return Task.FromResult<IEnumerable<ApiResource>>(apiSResources);
        }

        public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            var repo = new MongoRepository<Models.ApiScope>(mdbSettings);

            var list = repo.FilterBy(r => r.Enabled).ToList();

            var apiScopes = list.Select(resource => new ApiScope
            {
                Name = resource.Name,
                Enabled = true,
                DisplayName = resource.DisplayName,
                Description = resource.Description,
                UserClaims = resource.UserClaims
            });

            return Task.FromResult<IEnumerable<ApiScope>>(apiScopes);

        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var repo = new MongoRepository<Models.IdentityResource>(mdbSettings);

            var list = repo.FilterBy(r => r.Enabled).ToList();

            var identityResources = list.Select(resource => new IdentityResource
            {
                Name = resource.Name,
                Enabled = true,
                DisplayName = resource.DisplayName,
                Description = resource.Description,
                UserClaims = resource.UserClaims
            });

            return Task.FromResult<IEnumerable<IdentityResource>>(identityResources);
        }


        public Task<Resources> GetAllResourcesAsync()
        {
            var resources = new Resources
            {
                IdentityResources = FindIdentityResourcesByScopeNameAsync(new List<string>().AsEnumerable()).GetAwaiter().GetResult().ToList(),
                ApiScopes = FindApiScopesByNameAsync(new List<string>().AsEnumerable()).GetAwaiter().GetResult().ToList(),
                ApiResources = FindApiResourcesByScopeNameAsync(new List<string>().AsEnumerable()).GetAwaiter().GetResult().ToList()
            };

            return Task.FromResult(resources);
        }
    }
    
}
