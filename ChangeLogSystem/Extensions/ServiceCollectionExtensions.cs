using ChangeLogSystem.Api.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ChangeLogSystem.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIOC(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            IOC.Dependencies.Register(serviceCollection, configuration);

            return serviceCollection;
        }

        public static IServiceCollection AddJwtBearerAuthentication(this IServiceCollection serviceCollection, AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            serviceCollection
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return serviceCollection;
        }
    }
}