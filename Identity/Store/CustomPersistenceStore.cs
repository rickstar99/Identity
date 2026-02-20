using AutoMapper;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;
using Identity.Models;
using MongoDbHelper;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CustomPersistenceStore : IPersistedGrantStore
{
    private readonly IMongoRepository _repository;
    private readonly IMapper _mapper;

    public CustomPersistenceStore(IMongoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task StoreAsync(PersistedGrant grant)
    {
        // 1. Map Duende model to your custom Mongo model
        var mongoGrant = _mapper.Map<PersistedGrants>(grant);

        // 2. Check for existing and replace
        var existing = await _repository.FindOneAsync<PersistedGrants>(x => x.Key == grant.Key);
        if (existing != null)
        {
            await _repository.DeleteOneAsync<PersistedGrants>(x => x.Id == existing.Id);
        }

        await _repository.InsertOneAsync(mongoGrant);
    }

    public async Task<PersistedGrant> GetAsync(string key)
    {
        var result = await _repository.FindOneAsync<PersistedGrants>(x => x.Key == key);
        return _mapper.Map<PersistedGrant>(result);
    }

    public async Task<IEnumerable<PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
    {
        var results = _repository.FindManyAsync<PersistedGrants>(x => x.SubjectId == filter.SubjectId);
        return _mapper.Map<IEnumerable<PersistedGrant>>(results);
    }

    public async Task RemoveAsync(string key)
    {
        await _repository.DeleteOneAsync<PersistedGrants>(x => x.Key == key);
    }

    public async Task RemoveAllAsync(PersistedGrantFilter filter)
    {
        await _repository.DeleteManyAsync<PersistedGrants>(x => x.SubjectId == filter.SubjectId);
    }
}