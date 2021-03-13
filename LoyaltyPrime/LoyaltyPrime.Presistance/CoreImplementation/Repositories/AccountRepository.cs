using LoyaltyPrime.Data.Enities;
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
            var accountByMembers = LoyaltyPrimeEntities.Account.Where(a => a.Member.Id == memberID).AsQueryable();
            return accountByMembers;
        }

        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<Account>> GetAccounts()
        {
            var accounts = LoyaltyPrimeEntities.Account.AsQueryable();
            return accounts;
        }
    }
}
