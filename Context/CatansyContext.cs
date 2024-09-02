using Microsoft.EntityFrameworkCore;
using Catansy.API.Entities;
using Catansy.API.Interceptors;

namespace Catansy.API.Context;

public class CatansyContext : DbContext
{
    public CatansyContext(DbContextOptions<CatansyContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<ItemCategory> ItemsCategories { get; set; }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder
    //         .LogTo(Console.WriteLine, LogLevel.Information)
    //         .UseNpgsql("Host=116.203.138.176; Database=catansy; Username=postgres;Password=catansy");
    // }
}