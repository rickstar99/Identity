using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using Identity.Interface;
using Identity.Repository;
using Microsoft.Extensions.Logging;
using Identity.Security;

namespace Identity.Controllers
{
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {

        private readonly IMongoDbSettings _settings;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(IMongoDbSettings settings, ILogger<AccountsController> logger)
        {
            _settings = settings;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("connect/token")]
        public async Task<IActionResult> GenerateToken([FromBody] TokenRequestModel tokenRequest)
        {
            // Validate ClientId and ClientSecret
            if (!IsValidClient(tokenRequest.ClientId, tokenRequest.ClientSecret))
            {
                return Unauthorized("Invalid client credentials");
            }

            // Authenticate the user
            var user = await AuthenticateUserAsync(tokenRequest.Username, tokenRequest.Password);
            if (user == null)
            {
                return Unauthorized("Invalid user credentials");
            }

            // Generate JWT token
            var token = GenerateJwtToken(user);

            // Return the token
            return Ok(token);
        }

        private bool IsValidClient(string clientId, string clientSecret)
        {
            // Implement your logic to validate clientId and clientSecret
            return true;
        }

        private async Task<User> AuthenticateUserAsync(string email, string password)
        {
            // Implement your logic to authenticate user 

            var repo = new MongoRepository<User>(_logger, _settings);
            var user = repo.GetUserByEmail(email);

            if (user == null)
                return null;

            var salt = user.Salt;
            var hashedPassword = SecurePasswordHash.Hash(password, salt);

            if (hashedPassword == user.Password)
                return user;
            else
                return null;
        }

        private TokenResponse GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("XSMSebbduf0QS7UcmQmXH8cq3b-1r1l7DqAHwohzsVw"); // This should be a secure key

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.Id.ToString()),
                    // Add other claims as needed
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);

            return new TokenResponse
            {
                AccessToken = accessToken,
                // RefreshToken = "Implement if you have refresh token logic",
                ExpiresIn = 86400
            };
        }
    }
}
