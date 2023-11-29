using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace MyShop.IntegrationTest
{
    internal class MyShopApplication: WebApplicationFactory<Program>
    {
        private readonly string _environment;

        public MyShopApplication(string environment = "Development")
        {
            _environment = environment;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment(_environment);
            return base.CreateHost(builder);
        }
    }
}
