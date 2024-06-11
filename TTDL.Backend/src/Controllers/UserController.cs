using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using TTDL_Backend.Models;
using TTDL_Backend.Services;

namespace TTDL_Backend.Controllers
{
    /// <summary>
    /// The route for all user actions
    /// </summary>
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserservice _userService;

        public UserController(IUserservice userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// (add summary here)
        /// </summary>
        /// <returns></returns>
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

                    var result = new { match = _userService.LoginUser(uname, password)};

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

        /// <summary>
        /// (add summary here)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

