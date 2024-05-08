using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserservice _userService;

    public UserController(IUserservice userService)
    {
        _userService = userService;
    }

    [HttpGet("/get")]
    public IActionResult TestUser() => Ok("Shit works :)");
}