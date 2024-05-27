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

        [HttpGet("test")]
        public IActionResult test() => Ok("Je ken bij de backend :)");

        [HttpGet("getuser")]
        public IActionResult GetUserByUname([FromQuery] string? uname = null) => Ok(_userService.GetUserByUname(uname));

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] string user, string password) => Ok(_userService.RegisterUser(user, password));
    }
}

