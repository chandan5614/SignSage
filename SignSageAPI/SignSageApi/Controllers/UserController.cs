using Microsoft.AspNetCore.Mvc;
using SignSageApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/user/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var userDto = await _userService.GetUserByIdAsync(id);
        if (userDto != null)
        {
            return Ok(userDto);
        }
        return NotFound();
    }

    // GET: api/user
    [HttpGet]
    public async Task<IActionResult> ListUsers()
    {
        var users = await _userService.ListUsersAsync();
        return Ok(users);
    }

    // POST: api/user
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
    {
        var user = new User
        {
            id = userDto.Id,
            Username = userDto.UserName,
            Email = userDto.Email
        };

        var createdUser = await _userService.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
    }

    // PUT: api/user/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] UserDTO userDto)
    {
        var updated = await _userService.UpdateUserAsync(id, userDto);
        if (updated)
        {
            return NoContent();
        }
        return NotFound();
    }

    // DELETE: api/user/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var deleted = await _userService.DeleteUserAsync(id);
        if (deleted)
        {
            return NoContent();
        }
        return NotFound();
    }
}
