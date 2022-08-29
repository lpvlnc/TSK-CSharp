using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System;

namespace TSK.Security
{
    public static class Cryptography
    {
        public static string GenerateHash(string source)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
            byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        }

        public static bool CompareHash(string hash1, string hash2)
        {
            return hash1.Equals(hash2);
        }
    }
}
