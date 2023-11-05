using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace Identity.Models
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
