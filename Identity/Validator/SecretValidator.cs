using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Validator
{
    public class SecretValidator : ISecretValidator
    {
        public SecretValidator()
        {

        } 

        public async Task<SecretValidationResult> ValidateAsync(IEnumerable<Secret> secrets, ParsedSecret parsedSecret)
        {
            var secretValue = parsedSecret.Credential as string; // this is the secret sent by the client

            foreach (var secret in secrets)
            {
                if (HashFunction(secretValue) == secret.Value)
                {
                    return new SecretValidationResult { Success = true };
                }
            }

            return new SecretValidationResult { Success = false };
        }

        private string HashFunction(string value)
        {
            return value.Sha256();
        }
    }
}
