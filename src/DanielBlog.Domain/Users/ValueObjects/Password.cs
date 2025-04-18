using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DanielBlog.Domain.Users.ValueObjects;

public record Password
{
    public string HashedValue { get; init; }
    public string Salt { get; init; }
    
    public Password(string hashedValue, string salt)
    {
        if (string.IsNullOrWhiteSpace(hashedValue))
        {
            throw new ArgumentException("Hashed value cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(salt))
        {
            throw new ArgumentException("Salt cannot be empty.");
        }

        HashedValue = hashedValue;
        Salt = salt;
    }
    
    public Password(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be empty.");
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
        Console.WriteLine($"Stored Hash: {HashedValue}");
        Console.WriteLine($"Input Hash: {hashedInput}");
        Console.WriteLine($"Salt: {Salt}");
        return hashedInput == HashedValue;
    }
}