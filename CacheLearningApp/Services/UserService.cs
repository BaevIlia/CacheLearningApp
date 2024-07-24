using CacheLearningApp.Database;
using CacheLearningApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CacheLearningApp.Services
{
    public class UserService
    {
        PostgreSqlContext _context;
        IMemoryCache _cache;

        public UserService(PostgreSqlContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<User?> GetUser(int id)
        
        
        {
            _cache.TryGetValue(id, out User? user);

            if (user == null)
            {
                user = await _context.Users.Where(u=>u.Id == id).FirstOrDefaultAsync();
                if (user != null)
                {
                    Console.WriteLine($"{user.Name} извлечён из БД");
                    _cache.Set(user.Id, user,
                        new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
             
            }
            else
            {
                Console.WriteLine($"{user.Name} извлечен из кэша");
            }
            return user;
        }
    }
}
