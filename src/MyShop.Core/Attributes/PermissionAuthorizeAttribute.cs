using System.Runtime.Loader;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http;

namespace MyShop.Core.Attributes
{
    public class PermissionAuthorizeAttribute: AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
        }
    }
}
