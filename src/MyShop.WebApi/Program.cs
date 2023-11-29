using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyShop.Core.Models.Configs;
using MyShop.Core.Services.FileService;
using MyShop.Core.Services.TokenHandler;
using MyShop.Database.Data;
using Swashbuckle.Extensions;
using System.Runtime.CompilerServices;
using TokenHandlerService = MyShop.Core.Services.TokenHandler.TokenHandlerService;

[assembly: InternalsVisibleTo("MyShop.IntegrationTest")]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "my-shop", Version = "v1" });
    // Set the comments path for the Swagger JSON and UI.
    c.AddAutoRestCompatible();
    c.UseInlineDefinitionsForEnums();
    c.MakeValueTypePropertiesRequired();
    c.DefineOperationIdFromControllerNameAndActionName();
    c.EnableAnnotations();
});

builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection(JWTConfig.Name));
builder.Services.AddSingleton<ITokenHandlerService, TokenHandlerService>();
builder.Services.AddSingleton<IIndexFileService, IndexFileService>();
builder.Services.AddDbContext<MyShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyShopDbConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "my-shop");
            c.RoutePrefix = "swagger";
        });
    app.UseCors(options => options.AllowAnyOrigin());
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
//app.UseMiddleware<AuthenticationMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
