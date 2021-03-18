using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoyaltyPrime.Ground
{
    public static class Extensions
    {
        public static string GetFileExtension(this IFormFile file)
        {
            return Path.GetExtension(file.FileName);
        }
    }
}
