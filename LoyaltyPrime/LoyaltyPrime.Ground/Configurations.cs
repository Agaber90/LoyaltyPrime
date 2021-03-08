using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyPrime.Ground
{
    public static class Configurations
    {
        public static IConfiguration ConfigurationManager { get; set; }

        static string _LoyaltyPrimeConnectionString;
        public static string QorrectConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_LoyaltyPrimeConnectionString))
                    _LoyaltyPrimeConnectionString = GetConnectionString("LoyaltyPrimeConnectionString");
                return _LoyaltyPrimeConnectionString;
            }
        }

        public static string GetConnectionString(string appSettingsKey)
        {
            var cs = ConfigurationManager.GetConnectionString(appSettingsKey);
            if (cs != null)
                return cs;

            return null;
        }
    }
}
