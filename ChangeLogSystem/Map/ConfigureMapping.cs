using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangeLogSystem.Domain;
using ChangeLogSystem.Api;
using ChangeLogSystem.Shared;

namespace ChangeLogSystem.Api.Map
{
    public class ConfigureMapping : Profile
    {
        public ConfigureMapping()
        {
            #region Api to Domain Mappings

            CreateMap<DTOs.LoginDTO, Domain.Models.ILoginModel>()
                .IgnoreAllUnmapped();

            CreateMap<DTOs.UserDTO, Domain.Models.IUserModel>()
                .IgnoreAllUnmapped();

            #endregion Api to Domain Mappings
        }
    }
}