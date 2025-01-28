using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.WebApi.Models;

namespace MyShop.Core.Services
{
    public interface IAccountService
    {
        Task VerifyUserCredential(User user);
    }

    public class AccountService : IAccountService
    {
        public async Task VerifyUserCredential(User user)
        {
            
        }
    }
}
