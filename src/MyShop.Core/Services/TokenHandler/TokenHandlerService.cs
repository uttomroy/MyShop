using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyShop.Core.Models;
using MyShop.Core.Models.Configs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyShop.Core.Services.TokenHandler
{
    public class TokenHandlerService : ITokenHandlerService
    {
        private readonly JWTConfig _jwtConfig;
        public TokenHandlerService(IOptions<JWTConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        public async Task<Token> GetToken()
        {
            return new Token()
            {
                JWT = GetAccessToken(),
                RefreshToken = GetRreshToken()
            };
        }

        public Task<bool> IsTokenExpired(string token)
        {
            throw new NotImplementedException();
        }

        public bool IsValidToken(string token, string key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, GetValidationParameters(key), out _);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public  async Task<Token> RenewToken(string refreshToken)
        {
            if (!IsValidToken(refreshToken, _jwtConfig.RefreshTokenKey))
            {

                return null;
            }

            return new Token()
            {
                JWT = GetAccessToken(),
                RefreshToken = GetRreshToken()
            };

        }

        private TokenValidationParameters GetValidationParameters(string key)
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidIssuer = _jwtConfig.Issuer,
                ValidAudience = _jwtConfig.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };
        }

        private string GetAccessToken()
        {
            var issuer = _jwtConfig.Issuer;
            var audience = _jwtConfig.Audience;
            var key = Encoding.ASCII.GetBytes
                (_jwtConfig.AccessTokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, "Pradip"),
                    new Claim(JwtRegisteredClaimNames.Email, "pradip@gmail.com"),
                    new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        private string GetRreshToken()
        {
            var issuer = _jwtConfig.Issuer;
            var audience = _jwtConfig.Audience;
            var key = Encoding.ASCII.GetBytes
                (_jwtConfig.RefreshTokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, "Pradip"),
                    new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
