using Identity.Interface;
using MongoDbHelper;
using System;

namespace Identity.Extensions
{
    public class Document : IDocument
    {
        public string Id { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
