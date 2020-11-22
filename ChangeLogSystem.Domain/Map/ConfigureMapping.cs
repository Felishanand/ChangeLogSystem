using AutoMapper;
using ChangeLogSystem.Domain.Models;
using ChangeLogSystem.Data.Models;
using ChangeLogSystem.Shared;

namespace ChangeLogSystem.Domain.Map
{
    public class ConfigureMapping : Profile
    {
        public ConfigureMapping()
        {
            #region Domain to Data Mappings

            CreateMap<IUserModel, Users>().IgnoreAllUnmapped();

            #endregion Domain to Data Mappings

            #region Data to Domain Mappings

            CreateMap<Login, ILoginModel>().IgnoreAllUnmapped();
            CreateMap<Users, IUserModel>().IgnoreAllUnmapped();

            #endregion Data to Domain Mappings
        }
    }
}