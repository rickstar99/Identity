using Duende.IdentityServer.Models;
using Identity.Interface;
using MongoDbHelper;
using System;

namespace Identity.Models
{
    public class PersistedGrants : PersistedGrant, IDocument
    {
        public string Id { get; set; }
        public DateTime DateAdded;
    }
}
