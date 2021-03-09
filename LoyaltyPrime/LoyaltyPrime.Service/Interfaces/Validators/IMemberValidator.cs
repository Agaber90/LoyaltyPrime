using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces.Validators
{
    public interface IMemberValidator
    {
        Task<ValidatorResult> ValidateMemberName(string memberName);
        Task<ValidatorResult> ValidateMemberEmail(string memberEmail);
        Task<ValidatorResult> ValidateMemberEmailPattern(string memberEmail);

    }
}
