using ChangeLogSystem.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace ChangeLogSystem.Api.Common
{
    public class BaseController : ControllerBase
    {
        public AppSettings AppSettings => HttpContext.RequestServices.GetService<IOptions<AppSettings>>().Value;
        public ModelManager ModelManager => HttpContext.RequestServices.GetService<ModelManager>();
        public ServiceManager ServiceManager => HttpContext.RequestServices.GetService<ServiceManager>();
    }
}