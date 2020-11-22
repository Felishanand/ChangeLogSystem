using System.Threading.Tasks;
using ChangeLogSystem.Business.Models;
using ChangeLogSystem.Domain.Common;

namespace ChangeLogSystem.Business.Services
{
    public interface ILoginService : IBaseService
    {
        Task<bool> CheckLogin(ILoginModel model);
    }
}