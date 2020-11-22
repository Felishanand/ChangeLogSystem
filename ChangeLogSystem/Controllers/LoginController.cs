using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChangeLogSystem.Api.Common;
using ChangeLogSystem.Api.DTOs;
using ChangeLogSystem.Api.Helpers;
using ChangeLogSystem.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChangeLogSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Auth(LoginDTO model)
        {
            ILoginModel loginModel = ModelManager.Login;
            Mapper.Map<LoginDTO, ILoginModel>(model, loginModel);

            bool isAuthenticated = await ServiceManager.LoginService.CheckLogin(loginModel);

            string token = string.Empty;

            if (isAuthenticated)
                token = JwtTokenhelper.Token(AppSettings.Secret, loginModel);

            return Ok(new { token });
        }
    }
}