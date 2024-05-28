using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TTDL_Backend.Models;
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

        [HttpPost("login")]
        public async Task<IActionResult> LogUserIn()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var jsonDoc = JsonDocument.Parse(body);
                var root = jsonDoc.RootElement;

                if (root.TryGetProperty("uname", out JsonElement unameElement) &&
                    root.TryGetProperty("password", out JsonElement passwordElement))
                {
                    string uname = unameElement.GetString();
                    string password = passwordElement.GetString();

                    if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(password))
                    {
                        return BadRequest("Invalid request data");
                    }

                    var result = _userService.LoginUser(uname, password);

                    if (result == null)
                    {
                        return Unauthorized("Invalid username or password");
                    }

                    return Ok(result);
                }
                else
                {
                    return BadRequest("Invalid request data");
                }
            }
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            if (Request == null)
            {
                return BadRequest("Invalid request data");
            }

            var result = _userService.RegisterUser(user);

            return Ok(result);
        }
    }
}

