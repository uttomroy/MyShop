using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyShop.WebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MyShop.Core.Attributes;
using MyShop.Core.Services.TokenHandler;
using TokenHandler = MyShop.Core.Services.TokenHandler.TokenHandlerService;
using Swashbuckle.AspNetCore.Annotations;

namespace MyShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenHandlerService _tokenHandler;
        public AccountController(IConfiguration configuration, ITokenHandlerService tokenHandler)
        {
            _configuration = configuration;
            _tokenHandler = tokenHandler;
        }

        [HttpPost("Get")]
        [SwaggerOperation(OperationId = "test")]
        public IActionResult Get()
        {
            var result = true;
            return Ok(result);
        }

        [HttpPost("Login")]
        //[SwaggerOperation(OperationId = "BookingLayout")]
        public async Task<IActionResult> Login(User user)
        {
            var token = await _tokenHandler.GetToken();
            HttpContext.Response.Cookies.Append("token", token.JWT, new CookieOptions(){ HttpOnly = true, MaxAge = new TimeSpan(365, 0, 0, 0) });
            HttpContext.Response.Cookies.Append("RefreshToken", token.RefreshToken, new CookieOptions() { HttpOnly = true, MaxAge = new TimeSpan(365, 0, 0, 0) });
            return Ok();
        }
    }
}
