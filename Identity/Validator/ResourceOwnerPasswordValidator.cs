using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using Identity.Interface;
using System.Threading.Tasks;

public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
{
    public readonly IUserStore _userStore;

    public ResourceOwnerPasswordValidator(IUserStore userStore)
        => _userStore = userStore;

    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        // Your logic to validate the username and password
        var user = _userStore.ValidateCredentials(context.UserName, context.Password);
        if (user != null)
        {
            context.Result = new GrantValidationResult(
                subject: user.Id.ToString(),
                authenticationMethod: "custom");
        }
        else
        {
            context.Result = new GrantValidationResult(
            TokenRequestErrors.InvalidGrant, "invalid custom credential");
        }

        return Task.CompletedTask;
    }
}
