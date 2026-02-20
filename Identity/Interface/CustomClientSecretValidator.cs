using System.Net.Http.Headers;
using System.Text;
using System;
using System.Threading.Tasks;
using Duende.IdentityServer.Validation;
using Identity.Store;
using Microsoft.AspNetCore.Http;
using Duende.IdentityServer.Stores;
using System.Linq;
using Duende.IdentityServer.Models;

public class CustomClientSecretValidator : IClientSecretValidator
{
    public readonly IClientStore clientStore;
    public async Task<ClientSecretValidationResult> ValidateAsync(HttpContext context)
    {
        // Assuming the client ID and secret are sent in the Authorization header as Basic auth (common for client credentials grant)
        if (context.Request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
            if (authHeaderValue.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty)).Split(':', 2);
                if (credentials.Length == 2)
                {
                    var clientId = credentials[0];
                    var clientSecret = credentials[1];

                    // Use your custom client store to find the client by ID
                    var client = await clientStore.FindClientByIdAsync(clientId);

                    if (client != null)
                    {
                        // Now you have the client, you can check if the secret matches one of the stored secrets for this client
                        if (client.ClientSecrets.Any(s => s.Value == clientSecret.Sha256()))
                        {
                            // If the client secret is valid, return success
                            return new ClientSecretValidationResult
                            {
                                IsError = false
                            };
                        }
                    }
                }
            }
        }

        // If the method hasn't returned by now, it means either the client ID/secret wasn't provided, or they were invalid
        return new ClientSecretValidationResult
        {
            IsError = true,
            Error = "Invalid client credentials"
        };
    }
}
