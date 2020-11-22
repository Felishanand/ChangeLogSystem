using System;
using Microsoft.Extensions.DependencyInjection;
using ChangeLogSystem.Domain.Models;

namespace ChangeLogSystem.Domain.Common
{
    public class ModelManager
    {
        private readonly IServiceProvider _serviceProvider;

        public ModelManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUserModel User => _serviceProvider.GetService<IUserModel>();
        public ILoginModel Login => _serviceProvider.GetService<ILoginModel>();
    }
}