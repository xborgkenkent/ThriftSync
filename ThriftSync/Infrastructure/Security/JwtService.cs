using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ThriftSync.Domain.Entities;

namespace ThriftSync.Infrastructure.Security;

public class JwtService
{
    private readonly JwtOptions _jwtOptions;
    
    public JwtService(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public string GenerateJwtToken(User user)
    {
        if (string.IsNullOrWhiteSpace(_jwtOptions.Key) || _jwtOptions.Key.Length < 32)
        {
            throw new InvalidOperationException("JWT key must be at least 256 bits (32 characters).");
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Standard way to store UserId
            new Claim(ClaimTypes.Email, user.Email), // Standard way to store Email
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Prevent token replay
        };

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            expires: DateTime.UtcNow.AddHours(3),
            signingCredentials: credentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }
}