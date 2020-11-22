using System.Threading.Tasks;
using ChangeLogSystem.Business.Common;
using ChangeLogSystem.Business.Models;

namespace ChangeLogSystem.Business.Services
{
    public interface IUserService : IBaseService
    {
        Task Save(IUserModel model);

        Task<IUserModel> GetUser(int userId);
    }
}