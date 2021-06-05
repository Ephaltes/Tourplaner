using System;
using System.Linq;
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
                string resp = "";
                foreach (var i in result)
                {
                    resp += i.ToString("x2");
                }

                return resp;
            }
        }
    }
}