using Identity.Extensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbHelper;
using System.Collections.Generic;
using System.Security.Claims;

namespace Identity.Models
{
    [BsonIgnoreExtraElements]
    [BsonCollection("users")]
    public class Users : Document
    {
        public string Password { get; set; }
        public string Username { get; set; }
      
        public Users()
        {

        }

    }
}
