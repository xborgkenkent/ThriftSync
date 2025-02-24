using ThriftSync.Domain.Entities;

namespace ThriftSync.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> AddUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task<User?> GetUserByEmailAsync(string email);
    Task<bool> ValidateUserCredentialsAsync(string hashPassword, string password);
}