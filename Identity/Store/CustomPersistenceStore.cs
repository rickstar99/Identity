using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Store
{
    public class CustomPersistenceStore : IPersistedGrantStore
    {
        public Task<IEnumerable<PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<PersistedGrant> GetAsync(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAllAsync(PersistedGrantFilter filter)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task StoreAsync(PersistedGrant grant)
        {
            throw new System.NotImplementedException();
        }
    }
}
