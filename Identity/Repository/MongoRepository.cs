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

namespace Identity.Repository
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        protected readonly ILogger _logger;
        protected readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(ILogger logger, IMongoDbSettings settings)
        {
            _logger = logger;

            var mcs = MongoClientSettings.FromConnectionString(settings.ConnectionString);

            mcs.ClusterConfigurator = cb =>
            {
                cb.Subscribe<CommandStartedEvent>(e =>
                {
                    _logger.LogDebug($"{e.CommandName} - {e.Command.ToJson()}");
                });
            };
            var database = new MongoClient(mcs).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>("users");
        }

        public TDocument GetUserByEmail(string email)
            => _collection.Find(Builders<TDocument>.Filter.Eq(u => u.Email, email)).SingleOrDefault();
    }
}
