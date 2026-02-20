using Duende.IdentityServer.Models;
using Identity.Interface;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbHelper;
using System;

namespace Identity.Models
{
    [BsonIgnoreExtraElements]
    [BsonCollection("identityResources")]
    public class IdentityResources : Duende.IdentityServer.Models.IdentityResource, IDocument
    {
        public string Id { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
