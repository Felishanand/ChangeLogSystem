using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ChangeLogSystem.Api.Common;
using ChangeLogSystem.Shared;

namespace ChangeLogSystem.Api.IOC
{
    public static class Dependencies
    {
        public static void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            Domain.IOC.Dependencies.Register(serviceCollection);

            serviceCollection.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            serviceCollection.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));

            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            serviceCollection.AddScoped<UserInfo>();
        }
    }
}