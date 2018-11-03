using System;
using System.Security.Cryptography;
using System.Text;

namespace CB.Blazor.Infrastructure.Extensions
{
    public static class CryptographyExtensions
    {
        public static string New()
        {
            return Guid.NewGuid().ToString().Sha256Base64().Replace("+", "x");
        }

        public static string Sha256Base64(this string value)
        {
            using (var sha = SHA256.Create())
            {
                var bytesValue = Encoding.UTF8.GetBytes(value);
                var bytesHash = sha.ComputeHash(bytesValue);

                var result = Convert.ToBase64String(bytesHash);

                return result;
            }
        }
    }
}
