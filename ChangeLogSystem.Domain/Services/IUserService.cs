using System.Threading.Tasks;
using ChangeLogSystem.Domain.Common;
using ChangeLogSystem.Domain.Models;

namespace ChangeLogSystem.Business.Services
{
    public interface IUserService : IBaseService
    {
        Task Save(IUserModel model);

        Task<IUserModel> GetUser(int userId);
    }
}