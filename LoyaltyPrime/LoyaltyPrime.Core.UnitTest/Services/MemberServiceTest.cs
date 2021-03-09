using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Implementation.Services;
using LoyaltyPrime.Service.Interfaces.Factories;
using LoyaltyPrime.Service.Interfaces.Repositories;
using LoyaltyPrime.Service.Interfaces.ServiceValidators;
using Moq;
using NUnit.Framework;
using System;

namespace LoyaltyPrime.Core.UnitTest.Services
{
    [TestFixture]
    public class MemberServiceTest
    {
        Mock<IMemberServiceValidator> mockMemberServiceValidator = null;
        Mock<IMemberFactory> mockMemberFactory = null;
        Mock<IMemberRepository> mockMemberRepository = null;

        private Lazy<IMemberServiceValidator> lazMemberServiceValidator = null;
        private Lazy<IMemberFactory> lazMemberFactory = null;
        private Lazy<IMemberRepository> lazyMemberRepository = null;

        MemberService memberService = null;

        [SetUp]
        public void SetUp()
        {
            mockMemberServiceValidator = new Mock<IMemberServiceValidator>();
            mockMemberFactory = new Mock<IMemberFactory>();
            mockMemberRepository = new Mock<IMemberRepository>();
            lazMemberServiceValidator = new Lazy<IMemberServiceValidator>(() => mockMemberServiceValidator.Object);
            lazMemberFactory = new Lazy<IMemberFactory>(() => mockMemberFactory.Object);
            lazyMemberRepository = new Lazy<IMemberRepository>(() => mockMemberRepository.Object);
            memberService = new MemberService(lazMemberServiceValidator, lazMemberFactory, lazyMemberRepository);
        }


        public void AddMember_WhenMemberWithWorngValidation()
        {
            DTOMember dTOMember = new DTOMember();

        }

    }
}
