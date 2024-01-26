using Identity.Interface;
using MongoDB.Bson;
using System;

namespace Identity.Models
{
    public class ApiScope : Duende.IdentityServer.Models.ApiScope, IDocument
    {
        public ObjectId Id { get; set; }         
        public DateTime DateAdded { get; set; }
    }
}
