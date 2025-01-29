using MyShop.Database.Data;
using MyShop.Database.Data.Entities;

namespace MyShop.Core.Repositories;

public interface IUserRepository
{
    Task<bool> AddNewUser(User user);
}

public class UserRepository(MyShopDbContext dbContext) : IUserRepository
{
    public async Task<bool> AddNewUser(User user)
    { 
        await dbContext.User.AddAsync(user);
        return true;
    }
}