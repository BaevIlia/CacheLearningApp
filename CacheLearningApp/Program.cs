using CacheLearningApp.Database;

namespace CacheLearningApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            builder.Services.AddScoped<ApplicationContext>();
            var app = builder.Build();

           app.MapControllers();

            app.Run();
        }
    }
}
