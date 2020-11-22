using System;
using System.Threading.Tasks;
using AutoMapper;
using ChangeLogSystem.Domain.Common;
using ChangeLogSystem.Domain.Models;
using ChangeLogSystem.Data.Models;
using ChangeLogSystem.Domain.Services;

namespace ChangeLogSystem.Business.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<IUserModel> GetUser(int userId)
        {
            var userDetail = await RepositoryManager.UserRepository.FirstOrDefaultAsync(u => u.UserId == userId);
            return Mapper.Map<Data.Models.Users, IUserModel>(userDetail);
        }

        public async Task Save(IUserModel model)
        {
            var user = await RepositoryManager.UserRepository.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user != null)
            {
                Mapper.Map<Users, IUserModel>(user, model);
                return;
            }

            var userModel = Mapper.Map<IUserModel, Users>(model);
            userModel.CreatedOn = DateTime.Now;

            await RepositoryManager.UserRepository.InsertAsync(userModel, true);

            Mapper.Map<Users, IUserModel>(userModel, model);
        }
    }
}