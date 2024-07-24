using CacheLearningApp.Database;
using CacheLearningApp.Database.Models;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CacheLearningApp.Services
{
    public class MockRedisUserService
    {
        PostgreSqlContext context;
        IDistributedCache cache;

        public MockRedisUserService(PostgreSqlContext context, IDistributedCache cache)
        {
            this.context = context;
            this.cache = cache;
        }

        public async Task<User?> GetUser(int id) 
        {
            User? user = null;

            var userString = await cache.GetStringAsync(id.ToString());

            if(userString != null)
                user = JsonSerializer.Deserialize<User>(userString);

            if (user == null)
            {
                user = await context.Users.FindAsync(id);

                if (user != null)
                {
                    Console.WriteLine($"{user.Name} извлечён из базы данных");

                    userString = JsonSerializer.Serialize(user);
                    await cache.SetStringAsync(user.Id.ToString(),
                        userString, new DistributedCacheEntryOptions
                        {
                            SlidingExpiration = TimeSpan.FromMinutes(2)
                        });
                }
            }
            else 
            {
                Console.WriteLine($"{user.Name} извлечён из кэша");
            }
            return user;
        }
    }
}
