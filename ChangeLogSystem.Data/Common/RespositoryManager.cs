using ChangeLogSystem.Data.Respositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ChangeLogSystem.Data.Common
{
    public class RespositoryManager
    {
        private readonly IServiceProvider _serviceProvider;

        public RespositoryManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUserRepository UserRepository => _serviceProvider.GetService<IUserRepository>();
        public ILoginRepository LoginRepository => _serviceProvider.GetService<ILoginRepository>();
    }
}