using System.Security.Cryptography;
using System.Text;

namespace E_Commerce_Store.Common;

internal static class PasswordHasher
{
    internal static string Hash(string password)
    {
        var builder = new StringBuilder();
        foreach (var b in SHA256.HashData(Encoding.UTF8.GetBytes(password)))
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }
}