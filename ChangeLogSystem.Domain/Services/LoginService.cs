using System;
using System.Threading.Tasks;
using AutoMapper;
using ChangeLogSystem.Domain.Common;
using ChangeLogSystem.Domain.Models;
using ChangeLogSystem.Data.Models;

namespace ChangeLogSystem.Domain.Services
{
    public class LoginService : BaseService, ILoginService
    {
        public LoginService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<bool> CheckLogin(ILoginModel model)
        {
            var login = await RepositoryManager.LoginRepository
                .FirstOrDefaultAsync(l => l.UserName == model.Username && l.Password == model.Password);

            Mapper.Map<Login, ILoginModel>(login, model);
            return login != null;
        }
    }
}