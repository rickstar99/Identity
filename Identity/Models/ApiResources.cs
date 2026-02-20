using Duende.IdentityServer.Models;
using Identity.Interface;
using MongoDbHelper;
using System;

namespace Identity.Models
{
    public class ApiResources : ApiResource, IDocument
    {
        public string Id { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
