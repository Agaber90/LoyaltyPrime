using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyPrime.Ground
{
    public enum ValidationStatusEnum
    {
        BadRequest = 400,
        NotFound = 404,
        Unauthorized = 401,
        Accepted = 202,
        OK = 200

    }

    public enum ValidationStatus
    {
        BadRequest = 400,
        NotFound = 404,
        Unauthorized = 401,
        Accepted = 202
    }

    public enum AccountStatus
    {
        Active = 1,
        Inactive = 2
    }

    public enum FileExtension
    {
        JSON = 1
    }
}
