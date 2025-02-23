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
}