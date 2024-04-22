using Duende.IdentityServer.Models;
using Identity.Interface;
using Identity.MongoDb;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Identity.Models
{
    [BsonIgnoreExtraElements]
    [BsonCollection("clients")]
    public class Clients : Duende.IdentityServer.Models.Client, IDocument
    {
        public DateTime DateAdded { get; set; }
        public ObjectId Id { get; set; }
    }
}
