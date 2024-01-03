using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace Identity.Interface
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);

    }
}
