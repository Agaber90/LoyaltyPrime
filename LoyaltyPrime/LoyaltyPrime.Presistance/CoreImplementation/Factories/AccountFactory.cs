using LoyaltyPrime.Data.Enities;
using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Interfaces.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Presistance.CoreImplementation.Factories
{
    public class AccountFactory : IAccountFactory
    {
        /// <summary>
        /// Map from dtoAccount to Account 
        /// </summary>
        /// <param name="dTOAccount"></param>
        /// <returns></returns>
        public async Task<Account> CreateAccount(DTOAccount dTOAccount)
        {
            return new Account()
            {
                Balance = dTOAccount.Balance,
                MemberId = dTOAccount.MemberId,
                Name = dTOAccount.Name,
                Status = (int)dTOAccount.Status == 1 ? true : false
            };
        }
    }
}
