using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Identity.Interface
{
    public interface IDocument
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
