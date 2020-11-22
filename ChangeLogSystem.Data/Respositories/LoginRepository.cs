using ChangeLogSystem.Data.Common;
using ChangeLogSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeLogSystem.Data.Respositories
{
    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        public LoginRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}