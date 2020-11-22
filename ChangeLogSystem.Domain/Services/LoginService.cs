using System;
using System.Threading.Tasks;
using AutoMapper;
using ChangeLogSystem.Business.Common;
using ChangeLogSystem.Business.Models;
using ChangeLogSystem.Data.Models;

namespace ChangeLogSystem.Business.Services
{
    public class LoginService : BaseService, ILoginService
    {
        public LoginService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<bool> CheckLogin(ILoginModel model)
        {
            var login = await RepositoryManager.LoginRepository
                .FirstOrDefaultAsync(l => l.Username == model.Username && l.Password == model.Password);

            Mapper.Map<Login, ILoginModel>(login, model);
            return login != null;
        }
    }
}