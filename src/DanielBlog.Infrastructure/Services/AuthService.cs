using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DanielBlog.Domain.Users.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DanielBlog.Infrastructure.Services;

public sealed class AuthService(IConfiguration configuration, IUserRepository userRepository)
{
    private readonly string _secretKey = configuration.GetValue<string>("SecretKey")!;

    public string GenerateToken(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([new Claim(ClaimTypes.Name, username)]),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<bool> ValidateUserAsync(string username, string password)
    {
        var user = await userRepository.GetUserByUsernameAsync(username);
        if (user == null)
        {
            return false;
        }

        return password == user.Password.Value;
    }
}
