using Catansy.API.Configurations;
using Catansy.API.Context;
using Catansy.API.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WatchDog;
using WatchDog.src.Enums;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationConfiguration();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Logging.AddWatchDogLogger();

builder.Services.AddWatchDogServices(opt =>
{
    opt.IsAutoClear = true; 
    opt.SetExternalDbConnString = "Host=116.203.138.176; Database=logstest; Username=postgres;Password=catansy"; 
    opt.DbDriverOption = WatchDogDbDriverEnum.PostgreSql;
});

builder.Services.AddDbContext<CatansyContext>((sp, options) =>
{
    options
        // .AddInterceptors(new PerformanceInterceptor(sp.GetRequiredService<ILogger<PerformanceInterceptor>>()))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .UseNpgsql("Host=116.203.138.176; Database=catansy; Username=postgres;Password=catansy");
});

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseWatchDog(opt => 
{ 
    opt.WatchPageUsername = "admin"; 
    opt.WatchPagePassword = "1";
    opt.Blacklist = "/auth/login, /auth/register";
});

app.Run();

