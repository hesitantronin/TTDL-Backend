using Microsoft.AspNetCore.Mvc;
using TTDL_Backend.Services;

namespace TTDL_Backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserservice _userService;

        public UserController(IUserservice userService)
        {
            _userService = userService;
        }

        [HttpGet("get")]
        public IActionResult TestUser() => Ok(_userService.GetUser());

        [HttpPost("post")]
        public IActionResult RegisterUser([FromBody] string user, string password) => Ok(_userService.RegisterUser(user, password));
    }
}

