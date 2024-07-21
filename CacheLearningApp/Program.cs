using CacheLearningApp.Database;
using CacheLearningApp.Services;

namespace CacheLearningApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
      

            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddTransient<UserService>();
            builder.Services.AddControllers();
           builder.Services.AddMemoryCache();
            var app = builder.Build();

           app.MapControllers();

           app.Run();
        }
    }
}
