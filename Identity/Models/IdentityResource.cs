using Duende.IdentityServer.Models;
using Identity.Interface;
using Identity.MongoDb;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Identity.Models
{
    [BsonIgnoreExtraElements]
    [BsonCollection("identityResource")]
    public class IdentityResource : Duende.IdentityServer.Models.IdentityResource, IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
