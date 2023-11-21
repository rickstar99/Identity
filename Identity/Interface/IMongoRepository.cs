using System.Threading.Tasks;

namespace Identity.Interface
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        TDocument GetUserByEmail(string email);
    }
}
