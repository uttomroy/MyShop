using MyShop.Core.Models;

namespace MyShop.Core.Services.TokenHandler
{
    public interface ITokenHandlerService
    {
        bool IsValidToken(string token, string key);
        Task<Token> GetToken();
        Task<Token> RenewToken(string refreshToken);
        Task<bool> IsTokenExpired(string token);
    }
}
