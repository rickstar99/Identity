using Identity.Interface;
using Identity.MongoDb;
using MongoDB.Bson;
using System;

namespace Identity.Models
{
    public class ApiScopes : Duende.IdentityServer.Models.ApiScope, IDocument
    {
        public ObjectId Id { get; set; }         
        public DateTime DateAdded { get; set; }
    }
}
