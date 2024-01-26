using System.Linq.Expressions;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Identity.Interface
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);
        IEnumerable<TDocument> GetAll();

    }
}
