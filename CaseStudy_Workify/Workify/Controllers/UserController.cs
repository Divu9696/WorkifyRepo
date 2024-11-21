using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workify.Models;
using Workify.Services;

namespace Workify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateUser([FromBody] User user)
    {
        var authenticatedUser = await _userService.AuthenticateUserAsync(user.Email, user.Password);
        if (authenticatedUser == null)
            return Unauthorized();
        return Ok(authenticatedUser);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        await _userService.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user);
    }
    }
}
