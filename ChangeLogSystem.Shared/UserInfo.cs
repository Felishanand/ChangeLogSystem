using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ChangeLogSystem.Shared
{
    public class UserInfo
    {
        public UserInfo(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext httpContext = httpContextAccessor.HttpContext;

            Claim userId = httpContext.User.FindFirst(x => x.Type == ClaimTypes.UserData);

            if (userId != null)
            {
                UserId = Convert.ToInt32(userId.Value);
            }

            Claim firstNameClaim = httpContext.User.FindFirst(x => x.Type == ClaimTypes.Name);

            if (firstNameClaim != null)
            {
                Name = firstNameClaim.Value;
            }

            StringValues authorizationHeaders = httpContext.Request.Headers[Constants.REQUEST_HEADER_KEY_AUTHORIZATION];

            if (authorizationHeaders.Count > 0)
            {
                string authorizationHeader = authorizationHeaders[0];

                AccessToken = authorizationHeader.Replace($"{Constants.REQUEST_HEADER_KEY_AUTHORIZATION_SCHEME} ", string.Empty);
            }
        }

        public string AccessToken { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}