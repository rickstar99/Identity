using System.Security.Cryptography;
using System.Text;
using System;

namespace Identity.Security
{
    public static class SecurePasswordHash
    {
        private const int Iterations = 10000;
        private const int SaltSize = 16;
        private const int HashSize = 20;

        public static string Hash(string password, string key)
        {
            // Create salt
            byte[] salt;
            if (string.IsNullOrEmpty(key))
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);
            else
                salt = Encoding.ASCII.GetBytes(key);

            // Create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            // Combine salt and hash
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);

            // Format hash with extra information
            return base64Hash;
        }
    }
}
