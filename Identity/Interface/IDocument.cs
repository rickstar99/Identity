using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Identity.Interface
{
    public interface IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
