using Microsoft.EntityFrameworkCore;
using CatansyAPI.Entities;
using CatansyAPI.Interceptors;

namespace CatansyAPI.Context;

public class CatansyContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<ItemCategory> ItemsCategories { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .LogTo(Console.WriteLine, LogLevel.Information)
            .AddInterceptors(new PerformanceInterceptor())
            .UseNpgsql("Host=116.203.138.176; Database=catansy; Username=postgres;Password=catansy");
    }
}