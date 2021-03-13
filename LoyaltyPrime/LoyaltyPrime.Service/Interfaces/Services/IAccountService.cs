using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces.Services
{
    public interface IAccountService
    {
        Task<ServiceResultDetail<DTOAccount>> AddAccount(DTOAccount accountModel);
    }
}
