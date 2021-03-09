using LoyaltyPrime.Data.Enities;
using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Interfaces.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Presistance.CoreImplementation.Factories
{
    public class MemberFactory : IMemberFactory
    {
        /// <summary>
        /// Map Member from Dto to the member entity
        /// </summary>
        /// <param name="memberModel"></param>
        /// <returns></returns>
        public async Task<Member> CreateMember(DTOMember memberModel)
        {
            return new Member()
            {
                Name = memberModel.Name,
                Email = memberModel.Email
            };
        }
    }
}
