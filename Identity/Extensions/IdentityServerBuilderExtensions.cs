using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Duende.IdentityServer.Validation;
using Identity.Store;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Extensions
{
    public static class IdentityServerBuilderExtensions
    {
  

            /// <summary>
        /// Configure ClientId / Secrets
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configurationOption"></param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddClients(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IClientStore, CustomClientStore>();
            builder.Services.AddTransient<ICorsPolicyService, InMemoryCorsPolicyService>();

            return builder;
        }

        public static IIdentityServerBuilder AddUsers(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<Interface.IUserStore, CustomUserStore>();
            builder.Services.AddTransient<ICorsPolicyService, InMemoryCorsPolicyService>();

            return builder;
        }

        public static IIdentityServerBuilder AddResources(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IResourceStore, CustomResourceStore>();
            builder.Services.AddTransient<ICorsPolicyService, InMemoryCorsPolicyService>();

            return builder;
        }
        public static IIdentityServerBuilder AddPersistenceGrants(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IPersistedGrantStore, CustomPersistenceStore>();
            builder.Services.AddTransient<ICorsPolicyService, InMemoryCorsPolicyService>();

            return builder;
        }
        public static IIdentityServerBuilder AddCustomSecretValidator(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IClientSecretValidator, CustomClientSecretValidator>();
            builder.Services.AddTransient<ICorsPolicyService, InMemoryCorsPolicyService>();

            return builder;
        }
    }
}
