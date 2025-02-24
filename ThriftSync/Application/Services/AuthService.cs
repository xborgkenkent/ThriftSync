using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ThriftSync.Domain.Interfaces;
using ThriftSync.Domain.Entities;
using ThriftSync.Infrastructure.Security;

namespace ThriftSync.Application.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly JwtService _jwtService;
    
    public AuthService(IUserRepository userRepository, IConfiguration configuration, JwtService jwtService)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _jwtService = jwtService;
    }

    public async Task<User?> RegisterUserAsync(string email, string username, string password)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(email);
        if (existingUser != null)
        {
            return null;
        }
        
        var newUser = new User{Username = username, Email = email, PasswordHash = password};
        
        return await _userRepository.AddUserAsync(newUser);
    }

    public async Task<string?> LoginUserAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user == null || !await _userRepository.ValidateUserCredentialsAsync(user.PasswordHash, password))
        {
            return null;
        }

        return _jwtService.GenerateJwtToken(user);
    }

}