using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Identity.ViewModels;
using Identity.Models;
using Newtonsoft.Json.Bson;
using MongoDB.Bson;

namespace Identity.Controllers 
{
    [Route("Accounts")]
    [ApiController]
    public class  AccountsController : Controller 
    {
            
        [Route("connect/token")]
        [HttpPost()]
        public async Task<IActionResult> Login()
        {
            // Validate user credentials and sign them in

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("thisIsASecretKeyForHmacSha256Algthm")); // Replace with your secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, "testUsername"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "SuperUser")

                }),
                Expires = DateTime.UtcNow.AddHours(1), // Set the token expiration
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            return Ok(new TokenResponse
            {
                AccessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
                RefreshToken = ObjectId.GenerateNewId().ToString(),
                TimeCreated = DateTime.Now
            });
        }
    }
}