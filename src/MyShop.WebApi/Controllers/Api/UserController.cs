using Microsoft.AspNetCore.Mvc;
using MyShop.Core.Models.dto;
using MyShop.Core.Services;
using MyShop.Core.Services.TokenHandler;
using MyShop.Database.Data;

namespace MyShop.WebApi.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class UserController (IUserService userService) : ControllerBase
{
    
    [HttpPost("{orgId}/add-user")]
    public async Task<IActionResult> AddUser(int orgId, UserSignUpRequest request)
    {
        await userService.AddNewUser(request, orgId);
        return Ok();
    }
}