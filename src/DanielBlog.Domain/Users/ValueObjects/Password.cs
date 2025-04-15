using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DanielBlog.Domain.Users.ValueObjects;

public record Password
{
    public string Value { get; init; }

    public Password(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            // todo add custom exception
        }

        if (password.Length is < 8 or > 20)
        {
            // todo add custom exception
        }

        Value = HashPassword(password);
    }
    
    public static implicit operator Password(string value) => new(value);

    private static string HashPassword(string password)
    {
        var salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return hashed;
    }
}