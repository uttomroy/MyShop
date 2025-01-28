using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyShop.Core.Models;
using MyShop.Core.Models.Configs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MyShop.WebApi.Models;

namespace MyShop.Core.Services.TokenHandler
{
    public class TokenHandlerService : ITokenHandlerService
    {
        private readonly JWTConfig _jwtConfig;
        public TokenHandlerService(IOptions<JWTConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        public string GenerateAccessToken(User user)
        {
            return GenerateToken(user);
        }
        
        public JwtStatus VerifyToken(string token)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.AccessTokenKey));
            
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key
            };
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                if (validatedToken is JwtSecurityToken jwtToken)
                {
                    var algorithm = jwtToken.Header.Alg;
                    if (algorithm != SecurityAlgorithms.HmacSha256)
                    {
                        throw new SecurityTokenException("Invalid token signing algorithm.");
                    }
                }
                return JwtStatus.Valid;
            }
            catch (SecurityTokenExpiredException ex)
            {
                return JwtStatus.Expired;
            }
            catch (Exception ex)
            {
                return JwtStatus.Invalid;
            }
        }

        private string GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes
                (_jwtConfig.AccessTokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserId .ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim("OrgId", user.OrgId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.TokenExpirationInMin),
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
