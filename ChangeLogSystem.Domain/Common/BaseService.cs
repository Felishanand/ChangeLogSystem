using ChangeLogSystem.Data.Common;
using System;
using Microsoft.Extensions.DependencyInjection;
using ChangeLogSystem.Shared;

namespace ChangeLogSystem.Domain.Common
{
    public class BaseService : IBaseService
    {
        private readonly IServiceProvider _serviceProvider;

        public BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ModelManager ModelManager => _serviceProvider.GetService<ModelManager>();
        public RespositoryManager RepositoryManager => _serviceProvider.GetService<RespositoryManager>();
        public ServiceManager ServiceManager => _serviceProvider.GetService<ServiceManager>();
        public UserInfo UserInfo => _serviceProvider.GetService<UserInfo>();
    }
}