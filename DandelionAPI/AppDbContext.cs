using DandelionAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;

namespace DandelionAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseNpgsql("Host=localhost;port=5432;Database=test_db;Username=root;Password=root");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}