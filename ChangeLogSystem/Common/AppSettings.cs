using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeLogSystem.Api.Common
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public ApiAppSettings Api { get; set; }
    }

    public class ApiAppSettings
    {
        public CorsAppSettings Cors { get; set; }
    }

    public class CorsAppSettings
    {
        public List<string> AllowedOrigins { get; set; }
    }
}