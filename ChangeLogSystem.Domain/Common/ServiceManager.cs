using ChangeLogSystem.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;
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