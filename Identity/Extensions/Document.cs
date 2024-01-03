using Identity.Interface;
using MongoDB.Bson;
using System;

namespace Identity.Extensions
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
