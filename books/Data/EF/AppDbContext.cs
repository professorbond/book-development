using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Data.Entities;
namespace MyBlazorApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Phone> Phones { get; set; } = null!;
    }
}