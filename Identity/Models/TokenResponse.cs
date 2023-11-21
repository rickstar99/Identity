using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace Identity.Models
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; } // Optional, if you implement refresh tokens
        public int ExpiresIn { get; set; }
    }
}
