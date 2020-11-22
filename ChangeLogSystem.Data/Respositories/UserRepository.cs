using ChangeLogSystem.Data.Common;
using ChangeLogSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeLogSystem.Data.Respositories
{
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        public UserRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}