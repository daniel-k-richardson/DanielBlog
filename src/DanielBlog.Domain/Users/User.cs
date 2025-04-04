using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DanielBlog.Domain.Users;

public sealed class User : Entity
{
    public string Username { get; init; }
    public string Password { get; init; }

    public User(Guid id, string username, string password)
    {
        Id = id;
        Username = username;
        Password = HashPassword(password);
    }

    private string HashPassword(string password)
    {
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return hashed;
    }
}