using System.Threading.Tasks;
using AutoMapper;
using ChangeLogSystem.Api.Common;
using ChangeLogSystem.Api.DTOs;
using ChangeLogSystem.Api.Helpers;
using ChangeLogSystem.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChangeLogSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authunticate(UserDTO model)
        {
            IUserModel userModel = ModelManager.User;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, IUserModel>());

            Mapper.Map<UserDTO, IUserModel>(model, userModel);

            ILoginModel loginModel = ModelManager.Login;
            loginModel.Username = userModel.Email;
            loginModel.UserId = userModel.UserId;

            string token = string.Empty;

            if (loginModel != null)
                token = JwtTokenhelper.Token(AppSettings.Secret, loginModel);

            return Ok(new { token });
        }
    }
}