using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http;
using MyShop.Core.Services.TokenHandler;
using System;
using Microsoft.AspNetCore.Http;

namespace MyShop.Core.Attributes
{
    public class PermissionAuthorizeAttribute: AuthenticateService, IAuthorizationFilter
    {
        private readonly ITokenHandlerService _tokenHandlerService;

        public PermissionAuthorizeAttribute()
        {
            //HttpContext
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Cookies["token"]?.ToString();
            if (string.IsNullOrEmpty(token))
            {
               // var obj = ;
            }
        }
    }
}
