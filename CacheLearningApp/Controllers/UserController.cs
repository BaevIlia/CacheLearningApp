using CacheLearningApp.Database;
using CacheLearningApp.Database.Models;
using CacheLearningApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CacheLearningApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public UserController(ApplicationContext context)
        {
            _context = context;
        }



        [HttpGet("getAllUsers")]
        public IActionResult GetAll() 
        {
            return Ok(_context.User.ToList());
        }
    }
}
