using Duende.IdentityServer.Models;
using Identity.Interface;
using Identity.MongoDb;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Identity.Models
{
    [BsonIgnoreExtraElements]
    [BsonCollection("Client")]
    public class Client : Duende.IdentityServer.Models.Client, IDocument
    {
        public DateTime DateAdded { get; set; }
        public ObjectId Id { get; set; }
    }
}
