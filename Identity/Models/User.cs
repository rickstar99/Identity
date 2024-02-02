using Identity.Extensions;
using Identity.MongoDb;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Security.Claims;

namespace Identity.Models
{
    [BsonIgnoreExtraElements]
    [BsonCollection("user")]
    public class User : Document
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public User()
        {

        }

    }
}
