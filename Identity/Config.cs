using Duende.IdentityServer.Models;
using System.Collections.Generic;

namespace Identity { 

    public static class Config
    {
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                 new Client
                    {
                        ClientId = "test_client",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets = { new Secret("cl13n7".Sha256()) },
                        RefreshTokenExpiration = TokenExpiration.Sliding,
                        AllowedScopes = { "test_client" },
                        AccessTokenLifetime = 3600,
                    }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {        
                new ApiResource("scraper_api", "My API")
                {
                    Scopes = { "scraper_api" }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("scraper_api", "Access to My API")
            };
    }
}