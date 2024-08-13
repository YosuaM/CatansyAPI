using CatansyAPI.Context;
using CatansyAPI.Interceptors;
using CatansyAPI.Repositories;
using CatansyAPI.Repositories.Interfaces;
using CatansyAPI.Services;
using CatansyAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsersReadOnlyRepository, UsersReadOnlyRepository>();

builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddDbContext<CatansyContext>();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

