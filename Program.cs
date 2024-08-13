using CatansyAPI.Configurations;
using CatansyAPI.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddDbContext<CatansyContext>();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();

