using ChangeLogSystem.Data.Common;
using ChangeLogSystem.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeLogSystem.Domain.Common
{
    public interface IBaseService
    {
        ModelManager ModelManager { get; }
        RespositoryManager RepositoryManager { get; }
        ServiceManager ServiceManager { get; }
        UserInfo UserInfo { get; }
    }
}