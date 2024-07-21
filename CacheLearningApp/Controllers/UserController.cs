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
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id) 
        {
            return Ok(await _userService.GetUser(id));
        }
    }
}
