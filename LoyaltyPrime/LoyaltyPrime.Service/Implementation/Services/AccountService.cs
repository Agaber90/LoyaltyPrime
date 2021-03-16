using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Language.Resources;
using LoyaltyPrime.Service.Interfaces.Factories;
using LoyaltyPrime.Service.Interfaces.Repositories;
using LoyaltyPrime.Service.Interfaces.Services;
using LoyaltyPrime.Service.Interfaces.ServiceValidators;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Implementation.Services
{
    public class AccountService : IAccountService
    {
        private readonly Lazy<IAccountServiceValidator> _accountServiceValidator;
        private readonly Lazy<IAccountRepository> _accountRepository;
        private readonly Lazy<IAccountFactory> _accountFactory;
        private readonly Lazy<IMemberRepository> _memberRepository;
        public AccountService(Lazy<IAccountServiceValidator> accountServiceValidator,
                              Lazy<IAccountRepository> accountRepository,
                              Lazy<IMemberRepository> memberRepository,
                              Lazy<IAccountFactory> accountFactory)
        {
            _accountServiceValidator = accountServiceValidator;
            _accountRepository = accountRepository;
            _memberRepository = memberRepository;
            _accountFactory = accountFactory;
        }

        private IAccountServiceValidator AccountServiceValidator => _accountServiceValidator.Value;
        private IAccountRepository AccountRepository => _accountRepository.Value;
        private IAccountFactory AccountFactory => _accountFactory.Value;
        private IMemberRepository MemberRepository => _memberRepository.Value;

        /// <summary>
        /// Add Acocunt Services
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public async Task<ServiceResultDetail<DTOAccount>> AddAccount(DTOAccount accountModel)
        {
            var validateAccount = await AccountServiceValidator.AddAccountValidator(accountModel);
            if (!validateAccount.IsValid)
            {
                return new ServiceResultDetail<DTOAccount>()
                {
                    IsValid = false,
                    Messages = new List<string>() { validateAccount.Message }
                };
            }

            var hasAccountMember = MemberRepository.GetMemberById(accountModel.MemberId).Result is null ? false : true;

            var accountMemberValidator = await AccountServiceValidator.MemberHasAccountValidator(hasAccountMember);
            if (!accountMemberValidator.IsValid)
            {
                return new ServiceResultDetail<DTOAccount>()
                {
                    IsValid = false,
                    Messages = new List<string>() { accountMemberValidator.Message }
                };
            }

            var createAccount = await AccountFactory.CreateAccount(accountModel);

            if (accountModel.Id == null)
            {
                await AccountRepository.Create(createAccount);
            }

            var result = await AccountRepository.SaveChangesAsync();
            if (result)
            {
                accountModel.Id = createAccount.Id;
                return new ServiceResultDetail<DTOAccount>()
                {
                    Model = accountModel,
                };
            }
            return new ServiceResultDetail<DTOAccount>()
            {
                IsValid = false,
                Messages = new List<string>() { Resource.ErrorSaving }
            };
        }


        /// <summary>
        /// Member can collect points
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public async Task<ServiceResultDetail<DTOAccount>> CollectPointsByActiveAccount(long memberId)
        {
            var ActiveAccount = await AccountRepository.GetActiveAccounts(memberId);
            var validateActiveAccount = await AccountServiceValidator.AccountIsValidValidator(ActiveAccount.Any());
            if (!validateActiveAccount.IsValid)
            {
                return new ServiceResultDetail<DTOAccount>()
                {
                    IsValid = false,
                    Messages = new List<string>() { validateActiveAccount.Message },

                };
            }

            var sum = ActiveAccount.Sum(a => a.Balance);
            if (sum > 0)
            {
                return new ServiceResultDetail<DTOAccount>()
                {
                    SubTotalCount = (long)sum
                };
            }


            return new ServiceResultDetail<DTOAccount>();


        }

        public async Task<ServiceResultDetail<DTORedeemPoint>> RedeemPoints(DTORedeemPoint dTORedeemPoint)
        {
            var ActiveAccount = await AccountRepository.GetActiveAccounts(dTORedeemPoint.MemberId);
            var validateActiveAccount = await AccountServiceValidator.AccountIsValidValidator(ActiveAccount.Any());
            if (!validateActiveAccount.IsValid)
            {
                return new ServiceResultDetail<DTORedeemPoint>()
                {
                    IsValid = false,
                    Messages = new List<string>() { validateActiveAccount.Message },

                };
            }
            var sum = ActiveAccount.Sum(a => a.Balance);
            if (dTORedeemPoint.Point <= dTORedeemPoint.Point)
            {
                var newPoints = sum - dTORedeemPoint.Point;
                var redeemedPoint = new DTORedeemPoint
                {
                    MemberId = dTORedeemPoint.MemberId,
                    Point = newPoints
                };
                bool isRedeemed = await AccountRepository.UpdateRedeemeddAccounts(redeemedPoint);
                if (isRedeemed)
                {
                    return new ServiceResultDetail<DTORedeemPoint>()
                    {
                        Messages = new List<string>() { Resource.RedeemedSuccessMessage },
                    };
                }

            }
            return new ServiceResultDetail<DTORedeemPoint>();

        }

    }
}
