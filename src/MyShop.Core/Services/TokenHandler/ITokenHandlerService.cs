using MyShop.Core.Models;
using MyShop.WebApi.Models;

namespace MyShop.Core.Services.TokenHandler
{
    public interface ITokenHandlerService
    {
        string GenerateAccessToken(User user);
        JwtStatus VerifyToken(string token);
    }
}
