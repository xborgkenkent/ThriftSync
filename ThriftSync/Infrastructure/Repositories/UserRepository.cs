using Microsoft.EntityFrameworkCore;
using ThriftSync.Domain.Entities;
using ThriftSync.Domain.Interfaces;
using ThriftSync.Infrastructure.Data;
using BCrypt.Net;
namespace ThriftSync.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

    private readonly AppDbContext _context;
    
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> AddUserAsync(User user)
    {
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public Task<User> UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public Task<bool> ValidateUserCredentialsAsync(string email, string password)
    {
        throw new NotImplementedException();
    }
}