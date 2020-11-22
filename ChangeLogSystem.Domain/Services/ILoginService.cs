using System.Threading.Tasks;
using ChangeLogSystem.Domain.Common;
using ChangeLogSystem.Domain.Models;

namespace ChangeLogSystem.Domain.Services
{
    public interface ILoginService : IBaseService
    {
        Task<bool> CheckLogin(ILoginModel model);
    }
}