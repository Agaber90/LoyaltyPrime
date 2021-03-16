using LoyaltyPrime.Data.Enities;
using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Ground;
using LoyaltyPrime.Service.Interfaces;
using LoyaltyPrime.Service.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Presistance.CoreImplementation.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        protected readonly ILoyaltyPrimeDBEntities _loyaltyPrimeEntities;
        public AccountRepository(ILoyaltyPrimeDBEntities context) : base(context)
        {
            _loyaltyPrimeEntities = context;
        }
        protected ILoyaltyPrimeDBEntities LoyaltyPrimeEntities => _loyaltyPrimeEntities;

        /// <summary>
        /// Get Account by AcocuntID
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public async Task<Account> GetAccountById(long accountID)
        {
            var account = await LoyaltyPrimeEntities.Account.FirstOrDefaultAsync(a => a.Id == accountID);
            return account;
        }

        /// <summary>
        /// Get All Account by Member ID
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public async Task<IQueryable<Account>> GetAccountByMemberId(long memberID)
        {
            var accountByMembers = LoyaltyPrimeEntities.Account.Where(a => a.Member.Id == memberID);
            return accountByMembers;
        }

        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<Account>> GetAccounts()
        {
            var accounts = LoyaltyPrimeEntities.Account;
            return accounts;
        }

        /// <summary>
        /// Get Active Accounts
        /// </summary>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public async Task<IQueryable<Account>> GetActiveAccounts(long memberID)
        {
            var accountsByMember = LoyaltyPrimeEntities.Account.Where(a => a.Member.Id == memberID
            && a.Status == Convert.ToBoolean((int)AccountStatus.Active));
            return accountsByMember;
        }

        public async Task<bool> UpdateRedeemeddAccounts(DTORedeemPoint dTORedeemPoint)
        {
            var activeAccounts = await GetActiveAccounts(dTORedeemPoint.MemberId);
            if (activeAccounts.Any())
            {
                foreach (var item in activeAccounts)
                {
                    item.IsRedeemedPoint = true;
                    item.Balance = dTORedeemPoint.Point;
                }
                return await LoyaltyPrimeEntities.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
