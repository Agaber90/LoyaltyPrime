using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Interfaces.Validators;
using LoyaltyPrime.Service.Model;
using LoyaltyPrime.Language.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace LoyaltyPrime.Service.Implementation.Validators
{
    public class MemberValidator : IMemberValidator
    {
        /// <summary>
        /// Validate if member's email isn't empty
        /// </summary>
        /// <param name="memberEmail"></param>
        /// <returns></returns>
        public async Task<ValidatorResult> ValidateMemberAddress(string memberAddress)
        {
            if (string.IsNullOrEmpty(memberAddress))
            {
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = Resource.EmptyAddress
                };
            }
            return new ValidatorResult();
        }

       

        /// <summary>
        /// Validate if Member has a valid Name
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public async Task<ValidatorResult> ValidateMemberName(string memberName)
        {
            if (string.IsNullOrEmpty(memberName))
            {
                return new ValidatorResult()
                {
                    IsValid = false,
                    Message = Resource.EmptyName
                };
            }
            return new ValidatorResult();
        }

    }
}
