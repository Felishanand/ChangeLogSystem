using System;
using ChangeLogSystem.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChangeLogSystem.Domain.Common
{
    public class ServiceManager
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUserService UserService => _serviceProvider.GetService<IUserService>();
        public ILoginService LoginService => _serviceProvider.GetService<ILoginService>();
    }
}