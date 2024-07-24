using CacheLearningApp.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CacheLearningApp.Database
{
    public class SqlServerContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public SqlServerContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Database"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User {Id=1, Name="Tom", Age=23 },
                new User {Id=2, Name="Alice", Age=26 },
                new User {Id = 3, Name="Sam", Age=28 }
                );
        }
    }
}
