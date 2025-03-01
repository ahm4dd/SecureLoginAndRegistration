using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SecureLoginAndRegistration
{
    internal class Hashing
    {
        public static byte[] GenerateSalt()
        {
            const int saltSize = 64;
            byte[] salt = new byte[saltSize];
            var rng = RandomNumberGenerator.Create();

            rng.GetBytes(salt);
            return salt;
        }

        public static byte[] GenerateSha256Hash(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];
            Buffer.BlockCopy(salt, 0, saltedPassword, 0, salt.Length);
            Buffer.BlockCopy(passwordBytes, 0, saltedPassword, salt.Length, passwordBytes.Length);
            return SHA256.HashData(saltedPassword);
        }
    }
}
