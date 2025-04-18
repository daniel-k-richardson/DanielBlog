using System.Security.Cryptography;
using DanielBlog.Domain.Users.UsersExceptions;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DanielBlog.Domain.Users.ValueObjects;

public record Password
{
    public string HashedValue { get; init; }
    public string Salt { get; init; }
    
    // Parameterless constructor for EF Core
    private Password() { }
    
    public Password(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new PasswordNullOrEmptyException("Password cannot be empty");
        }
        
        Salt = GenerateSalt();
        HashedValue = HashPassword(password, Salt);
    }
    
    private static string GenerateSalt()
    {
        var salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return Convert.ToBase64String(salt);
    }

    private static string HashPassword(string password, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: saltBytes,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
    }

    public bool Verify(string password)
    {
        var hashedInput = HashPassword(password, Salt);
        return hashedInput == HashedValue;
    }
}