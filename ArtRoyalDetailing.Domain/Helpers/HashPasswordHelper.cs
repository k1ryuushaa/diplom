using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ArtRoyalDetailing.Domain.Helpers
{
    public static class HashPasswordHelper
    {
        public static string HashPassword(string password)
        {
            using(var sha256 = SHA256.Create())
            {
                var hashdBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashdBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
