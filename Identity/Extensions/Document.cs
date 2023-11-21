using Identity.Interface;
using MongoDB.Bson;
using System;

namespace Identity.Extensions
{
    public class Document : IDocument
    {
        public string Email { get; set ; }
        public string Password { get; set ; }
        public string Salt { get; set ; }
    }
}
