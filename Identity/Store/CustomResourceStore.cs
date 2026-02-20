using AutoMapper;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;
using Identity.Models;
using MongoDbHelper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Store
{
    public class CustomResourceStore : IResourceStore
    {
        private readonly IMongoRepository _repository;
        private readonly IMapper _mapper;

        public CustomResourceStore(IMongoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            var results = await _repository.FindManyAsync<ApiResources>(x => apiResourceNames.Contains(x.Name));
            return _mapper.Map<IEnumerable<ApiResource>>(results);
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            // Assuming your Mongo model has a Scopes list for filtering
            var results = await _repository.FindManyAsync<ApiResources>(x => x.Scopes.Any(s => scopeNames.Contains(s)));
            return _mapper.Map<IEnumerable<ApiResource>>(results);
        }

        public async Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            var results = await _repository.FindManyAsync<Models.ApiScopes>(x => scopeNames.Contains(x.Name));
            return _mapper.Map<IEnumerable<ApiScope>>(results);
        }

        public async Task<IEnumerable<Duende.IdentityServer.Models.IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var results = await _repository.FindManyAsync<Models.IdentityResources>(x => scopeNames.Contains(x.Name));
            return _mapper.Map<IEnumerable<IdentityResource>>(results);
        }

        public async Task<Resources> GetAllResourcesAsync()
        {
            var identity = await _repository.FindManyAsync<Models.IdentityResources>(x => true);
            var apiScopes = await _repository.FindManyAsync<ApiScopes>(x => true);
            var apiResources = await _repository.FindManyAsync<ApiResources>(x => true);

            return new Resources(
                _mapper.Map<IEnumerable<IdentityResource>>(identity),
                _mapper.Map<IEnumerable<ApiResource>>(apiResources),
                _mapper.Map<IEnumerable<ApiScope>>(apiScopes)
            );
        }
    }
}