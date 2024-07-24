using CacheLearningApp.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CacheLearningApp.Database
{
    public class PostgreSqlContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public PostgreSqlContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreSQL"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Tom", Age = 23 },
                new User { Id = 2, Name = "Alice", Age = 26 },
                new User { Id = 3, Name = "Sam", Age = 28 }
                );
        }

    }
}
