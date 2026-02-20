using Duende.IdentityServer.Models;
using Identity.Interface;
using Identity.Models;
using Identity.Security;
using MongoDbHelper;
using System.Threading.Tasks;

namespace Identity.Store
{
    public class CustomUserStore : IUserStore
    {
        private readonly IMongoRepository _repository;

        public CustomUserStore(IMongoRepository repository)
        {
            _repository = repository;
        }

        public Users ValidateCredentials(string username, string password)
        {
            return _repository.FindOne<Users>(u => u.Username == username && u.Password == SecurePasswordHash.Hash(password, username));
        }
    }
}