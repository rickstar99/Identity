using Duende.IdentityServer.Models;
using Identity.Interface;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbHelper;
using System;

namespace Identity.Models
{
    [BsonIgnoreExtraElements]
    [BsonCollection("clients")]
    public class ApiScopes : ApiScope, IDocument
    {
        public string Id { get; set; }         
        public DateTime DateAdded { get; set; }
    }
}
