using LoyaltyPrime.Data.Enities;
using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Language.Resources;
using LoyaltyPrime.Service.Interfaces.Factories;
using LoyaltyPrime.Service.Interfaces.Repositories;
using LoyaltyPrime.Service.Interfaces.Services;
using LoyaltyPrime.Service.Interfaces.ServiceValidators;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Implementation.Services
{
    public class MemberService : IMemberService
    {
        private readonly Lazy<IMemberServiceValidator> _memberServiceValidator;
        private readonly Lazy<IMemberFactory> _memberFactory;
        private readonly Lazy<IMemberRepository> _memberRepository;
        public MemberService(Lazy<IMemberServiceValidator> memberServiceValidator,
            Lazy<IMemberFactory> memberFactory,
            Lazy<IMemberRepository> memberRepository)
        {
            _memberServiceValidator = memberServiceValidator;
            _memberFactory = memberFactory;
            _memberRepository = memberRepository;
        }

        private IMemberServiceValidator MemberServiceValidator => _memberServiceValidator.Value;
        private IMemberFactory MemberFactory => _memberFactory.Value;
        private IMemberRepository MemberRepository => _memberRepository.Value;

        /// <summary>
        /// Add new Member
        /// </summary>
        /// <param name="memberModel"></param>
        /// <returns></returns>
        public async Task<ServiceResultDetail<DTOMember>> AddMember(DTOMember memberModel)
        {

            var validateMember = await MemberServiceValidator.AddEditMemberValidator(memberModel);
            if (!validateMember.IsValid)
            {
                return new ServiceResultDetail<DTOMember>()
                {
                    IsValid = false,
                    Messages = new List<string>() { validateMember.Message }
                };
            }
            var createMember = await MemberFactory.CreateMember(memberModel);
            if (memberModel.Id == null)
            {
                await MemberRepository.Create(createMember);

            }
            var result = await MemberRepository.SaveChangesAsync();
            if (result)
            {
                memberModel.Id = createMember.Id;
                return new ServiceResultDetail<DTOMember>()
                {
                    Model = memberModel
                };
            }
            return new ServiceResultDetail<DTOMember>()
            {
                IsValid = false,
                Messages = new List<string>() { Resource.ErrorSaving }
            };

        }
    }
}
