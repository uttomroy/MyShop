using MyShop.Core.Models.dto;
using MyShop.Core.Repositories;
using MyShop.Database.Data.Entities;

namespace MyShop.Core.Services;

public interface IUserService
{
    Task<bool> AddNewUser(UserSignUpRequest request, int orgId);
}

public class UserService (IUserRepository userRepository) : IUserService
{
    public async Task<bool> AddNewUser(UserSignUpRequest request, int orgId)
    {
        await userRepository.AddNewUser(
            new User()
            {
                Name = request.UserName,
                LocalName = request.LocalName,
                Password = GeneratePasswordHash(request.Password),
                OrgId = orgId,
                RoleId = request.RoleId,
            }
        );
        return true;
    }

    private string GeneratePasswordHash(string password)
    {
        return "";
    }
}