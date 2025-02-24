using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThriftSync.API.DTO;
using ThriftSync.Application.Services;

namespace ThriftSync.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthController: ControllerBase
{
    private readonly AuthService _authService;
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerDto)
    {
        var user = await _authService.RegisterUserAsync(registerDto.Email, registerDto.Username, registerDto.Password);
        if(user == null) return BadRequest(new { message = "Account already exists" });

        return Created();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
    {
        Console.WriteLine($"Email: {loginDto.Email}, Password: {loginDto.Password}");

        var token = await _authService.LoginUserAsync(loginDto.Email, loginDto.Password);
        if (token == null) return Unauthorized(new { message = "Invalid credentials" });
        
        Response.Cookies.Append("TS", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddHours(2)
        });
        
        return Ok();
    }
}