using System.Security.Claims;
using api.Modules.Auth.Models;
using api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Modules.Auth;

[AllowAnonymous]
public class AuthController : BaseController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly TokenService _tokenService;
    public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        TokenService tokenService)
    {
        _tokenService = tokenService;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDTO loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null) return Unauthorized();

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (result.Succeeded) await GenerateUserObject(user);

        return Unauthorized();
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDTO registerDto)
    {
        if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            return BadRequest("Email taken");

        // if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username)) return BadRequest("Username taken");

        var user = new AppUser
        {
            UserName = registerDto.Username,
            Email = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (result.Succeeded) await GenerateUserObject(user);

        return BadRequest("Error registering user");
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
        return await GenerateUserObject(user);
    }

    private async Task<UserDto> GenerateUserObject(AppUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        return new UserDto
        {
            DisplayName = user.Email,
            Image = string.Empty,
            Token = _tokenService.CreateToken(user),
            Roles = roles
        };
    }
}
