using Microsoft.EntityFrameworkCore;
using MyShop.Database.Data.Entities;

namespace MyShop.Database.Data
{
    public class MyShopDbContext : DbContext
    {
        public MyShopDbContext(DbContextOptions<MyShopDbContext> context) : base(context)
        {

        }

        public DbSet<Organization> Organization { get; set; }

    }
}
