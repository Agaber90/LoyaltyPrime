using LoyaltyPrime.Ground;
using LoyaltyPrime.Language.Resources;
using LoyaltyPrime.Service.Interfaces.Validators;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Implementation.Validators
{
    public class AccountValidator : IAccountValidator
    {
        /// <summary>
        /// Validate Account Balance
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        public async Task<ValidatorResult> ValidateAccountBalance(decimal balance)
        {
            if (balance <= 0)
            {
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = Resource.BalanceInCorrectFormat
                };
            }
            return new ValidatorResult();

        }

        /// <summary>
        /// Validate Account Name
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public async Task<ValidatorResult> ValidateAccountName(string accountName)
        {
            if (string.IsNullOrEmpty(accountName))
            {
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = Resource.EmptyAccountName
                };
            }
            return new ValidatorResult();
        }

        /// <summary>
        /// Validate Account Status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<ValidatorResult> ValidateAccountStatus(int status)
        {
            if ((int)AccountStatus.Active != status || (int)AccountStatus.Inactive == status)
            {
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = Resource.ValidateStatis
                };
            }
            return new ValidatorResult();
        }

        /// <summary>
        /// Validate Member is Exist
        /// </summary>
        /// <param name="isMEmberExist"></param>
        /// <returns></returns>
        public async Task<ValidatorResult> ValidateExistingMember(bool isMEmberExist)
        {
            if (!isMEmberExist)
            {
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = Resource.ValidateExistingMember
                };
            }
            return new ValidatorResult();
        }
    }
}
