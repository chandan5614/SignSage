using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignSageApi.Models;

[Authorize(Policy = "AdminPolicy")]
[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleService _roleService;

    public AdminController(IUserRepository userRepository, IRoleService roleService)
    {
        _userRepository = userRepository;
        _roleService = roleService;
    }

    // GET: api/admin/users
    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return Ok(users);
    }

    // GET: api/admin/roles
    [HttpGet("roles")]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleService.ListRolesAsync();
        return Ok(roles);
    }

    // POST: api/admin/users
    [HttpPost("users")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        var createdUser = await _userRepository.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetAllUsers), new { id = createdUser.id }, createdUser);
    }

    // POST: api/admin/roles
    [HttpPost("roles")]
    public async Task<IActionResult> CreateRole([FromBody] RoleCreateModel roleCreateModel)
    {
        var createdRole = await _roleService.CreateRoleAsync(roleCreateModel);
        return CreatedAtAction(nameof(GetAllRoles), new { id = createdRole.Id }, new RoleDTO
        {
            Id = createdRole.Id,
            Name = createdRole.Name
        });
    }
}
