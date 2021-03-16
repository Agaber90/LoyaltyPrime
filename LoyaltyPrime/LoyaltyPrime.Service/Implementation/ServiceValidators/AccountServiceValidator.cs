using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Interfaces.ServiceValidators;
using LoyaltyPrime.Service.Interfaces.Validators;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Implementation.ServiceValidators
{
    public class AccountServiceValidator : IAccountServiceValidator
    {
        private readonly Lazy<IAccountValidator> _accountValidator;

        public AccountServiceValidator(Lazy<IAccountValidator> accountValidator)
        {
            _accountValidator = accountValidator;
        }

        private IAccountValidator AccountValidator => _accountValidator.Value;

        /// <summary>
        /// Validate a newly account
        /// </summary>
        /// <param name="dTOAccount"></param>
        /// <returns></returns>
        public async Task<ValidatorResult> AddAccountValidator(DTOAccount dTOAccount)
        {
            var accountTask = new List<Task<ValidatorResult>>()
            {
                AccountValidator.ValidateAccountName(dTOAccount.Name),
                AccountValidator.ValidateAccountStatus((int)dTOAccount.Status),
                 AccountValidator.ValidateAccountBalance(dTOAccount.Balance),
            };
            await Task.WhenAll(accountTask);
            var taskResult = accountTask.Select(a => a.Result).FirstOrDefault(a => !a.IsValid);
            if (taskResult != null) return taskResult;
            return new ValidatorResult();
        }

        /// <summary>
        /// Validate Member is Exist
        /// </summary>
        /// <param name="isExist"></param>
        /// <returns></returns>
        public async Task<ValidatorResult> MemberHasAccountValidator(bool isExist)
        {

            var accountTask = new List<Task<ValidatorResult>>()
            {
                    AccountValidator.ValidateExistingMember(isExist),
            };

            await Task.WhenAll(accountTask);
            var taskResult = accountTask.Select(a => a.Result).FirstOrDefault(a => !a.IsValid);
            if (taskResult != null) return taskResult;
            return new ValidatorResult();
        }

        public async Task<ValidatorResult> AccountIsValidValidator(bool isActiveAccount)
        {
            var accountTask = new List<Task<ValidatorResult>>()
            {
                    AccountValidator.ValidateActiveAccount(isActiveAccount),
            };

            await Task.WhenAll(accountTask);
            var taskResult = accountTask.Select(a => a.Result).FirstOrDefault(a => !a.IsValid);
            if (taskResult != null) return taskResult;
            return new ValidatorResult();
        }
    }
}
