using System.Security.Cryptography;
using System;

namespace Identity.Security
{
    public class AesKeyGenerator
    {
        public static string Get(int size = 16)
        {
            var randomNumber = new byte[size];
            string key = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                key = Convert.ToBase64String(randomNumber);
            }
            return key;
        }
    }
}
