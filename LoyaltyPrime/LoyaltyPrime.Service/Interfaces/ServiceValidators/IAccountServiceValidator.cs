using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces.ServiceValidators
{
    public interface IAccountServiceValidator
    {
        Task<ValidatorResult> AddAccountValidator(DTOAccount dTOAccount);

        Task<ValidatorResult> MemberHasAccountValidator(bool isExist);
    }
}
