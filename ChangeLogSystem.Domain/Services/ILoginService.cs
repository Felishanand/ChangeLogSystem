using System.Threading.Tasks;
using ChangeLogSystem.Domain.Common;
using ChangeLogSystem.Domain.Models;

namespace ChangeLogSystem.Business.Services
{
    public interface ILoginService : IBaseService
    {
        Task<bool> CheckLogin(ILoginModel model);
    }
}