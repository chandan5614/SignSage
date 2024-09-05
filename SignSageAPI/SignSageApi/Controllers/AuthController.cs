using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignSageApi.Models;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, JwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            return BadRequest(new { message = "Passwords do not match" });
        }

        var user = new User 
        { 
            Username = model.UserName, 
            Email = model.Email 
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            if (!string.IsNullOrEmpty(model.Role))
            {
                await _userManager.AddToRoleAsync(user, model.Role);
            }
            return Ok(new { message = "User registered successfully" });
        }
        return BadRequest(result.Errors.Select(e => e.Description));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            var token = await _jwtTokenGenerator.GenerateTokenAsync(user);
            return Ok(new { Token = token });
        }
        return Unauthorized(new { message = "Invalid login attempt" });
    }
}
