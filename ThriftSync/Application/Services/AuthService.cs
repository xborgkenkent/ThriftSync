using ThriftSync.Domain.Interfaces;
using ThriftSync.Domain.Entities;
namespace ThriftSync.Application.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
}