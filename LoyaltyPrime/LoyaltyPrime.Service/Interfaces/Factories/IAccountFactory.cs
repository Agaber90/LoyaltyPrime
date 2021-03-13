using LoyaltyPrime.Data.Enities;
using LoyaltyPrime.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces.Factories
{
    public interface IAccountFactory
    {
        Task<Account> CreateAccount(DTOAccount dTOAccount);
    }
}
