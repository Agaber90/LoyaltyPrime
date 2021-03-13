using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces.Validators
{
    public interface IAccountValidator
    {
        Task<ValidatorResult> ValidateAccountName(string accountName);

        Task<ValidatorResult> ValidateAccountStatus(int status);

        Task<ValidatorResult> ValidateAccountBalance(decimal balance);

        Task<ValidatorResult> ValidateExistingMember(bool isMEmberExist);
    }
}
