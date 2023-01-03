using MyShop.Core.Middleware;
using MyShop.Core.Models.Configs;
using MyShop.Core.Services.TokenHandler;
using TokenHandlerService = MyShop.Core.Services.TokenHandler.TokenHandlerService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddSwaggerGen();
builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection(JWTConfig.Name));
builder.Services.AddSingleton<ITokenHandlerService, TokenHandlerService>();

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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseMiddleware<AuthenticationMiddleware>();

app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
