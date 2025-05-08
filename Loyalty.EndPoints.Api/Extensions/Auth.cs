using Keycloak.AuthServices.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static AuthorizationConstants;

namespace Loyalty.EndPoints.Api.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuth(
               this IServiceCollection services,
               IConfiguration configuration
           )
        {
            services.AddKeycloakWebApiAuthentication(configuration, x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    
                };
                
            });

            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy(
                       Policies.RequireAuth,
                       builder =>
                           builder
                               .RequireAuthenticatedUser()
                   );
                })
                //.AddKeycloakAuthorization(configuration)
                //.AddAuthorizationServer(configuration)
                ;

            return services;
        }
    }
}

public static class AuthorizationConstants
{


    public static class Policies
    {
        public const string RequireAuth = nameof(RequireAuth);
    }

}
