using System;
using System.Security.Cryptography;
using System.Text;

namespace TourService
{
    public class Sha256Wrapper
    {
        public static string Hash(string value)
        {
            using (var hash = SHA256.Create())            
            {
                Byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
                return Convert.ToBase64String(result);
            }
        }
    }
}