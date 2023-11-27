using DandelionAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DandelionAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;port=5432;Database=test_db;Username=root;Password=root");
        }

        public DbSet<User> Users { get; set; }
    }
}