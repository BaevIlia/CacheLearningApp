using CacheLearningApp.Database;
using CacheLearningApp.Services;

namespace CacheLearningApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<SqlServerContext>();
            builder.Services.AddScoped<PostgreSqlContext>();
            builder.Services.AddTransient<UserService>();
            builder.Services.AddTransient<MockRedisUserService>();
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost";
                options.InstanceName = "local";
            });
            builder.Services.AddControllers();
           builder.Services.AddMemoryCache();
            var app = builder.Build();

           app.MapControllers();

           app.Run();
        }
    }
}
