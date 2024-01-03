using Microsoft.Extensions.Options;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;
using Identity.Interface;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using Identity.Models;
using System.Linq.Expressions;

namespace Identity.Repository
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        protected readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IMongoDbSettings settings)
        {

            var mcs = MongoClientSettings.FromConnectionString(settings.ConnectionString);
            
            var database = new MongoClient(mcs).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>("client");
        }

        public TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

    }
}
