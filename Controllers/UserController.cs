using iShop.Models;
using iShop.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);

        if (user == null)
        {
            return NotFound(); // 404 Not Found if user not found
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        if (user == null)
        {
            return BadRequest(); // 400 Bad Request if user data is not provided
        }

        _userService.CreateUser(user);

        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        // 201 Created with a link to the newly created resource (user)
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
    {
        if (updatedUser == null || id != updatedUser.Id)
        {
            return BadRequest(); // 400 Bad Request if user data is not provided or ID mismatch
        }

        var existingUser = _userService.GetUserById(id);

        if (existingUser == null)
        {
            return NotFound(); // 404 Not Found if user not found
        }

        _userService.UpdateUser(updatedUser);

        return NoContent(); // 204 No Content if the update was successful
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _userService.GetUserById(id);

        if (user == null)
        {
            return NotFound(); // 404 Not Found if user not found
        }

        _userService.DeleteUser(id);

        return NoContent(); // 204 No Content if the deletion was successful
    }

    [HttpGet("count")]
    public IActionResult GetUserCount()
    {
        var userCount = _userService.GetUserCount();
        return Ok(userCount);
    }
}