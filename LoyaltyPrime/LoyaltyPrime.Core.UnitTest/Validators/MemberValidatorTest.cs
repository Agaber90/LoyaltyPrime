using LoyaltyPrime.Service.Implementation.Validators;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyPrime.Core.UnitTest.Validators
{
    [TestFixture]
    public class MemberValidatorTest
    {
        MemberValidator memberValidator = null;
        [SetUp]
        public void SetUp()
        {
            memberValidator = new MemberValidator();
        }

        [Test]
        public void ValidateMemberEmailPattern_WhenMemberHasValideEmail()
        {
            string email = "test@h.com";
            //Act
            var result = memberValidator.ValidateMemberEmailPattern(email).Result;

            //Asert
            Assert.That(result.IsValid);
        }

        [Test]
        public void ValidateMemberEmailPattern_WhenMemberHasInvalideEmail()
        {
            string email = "test@h";
            //Act
            var result = memberValidator.ValidateMemberEmailPattern(email).Result;

            //Asert
            Assert.That(!result.IsValid);
        }

        [Test]
        public void ValidateMemberEmail_WhenMemberHasNotEmptyEmail()
        {
            string email = "test@h.com";
            //Act
            var result = memberValidator.ValidateMemberEmail(email).Result;

            //Asert
            Assert.That(result.IsValid);
        }

        [Test]
        public void ValidateMemberEmail_WhenMemberHasEmptyEmail()
        {
            string email = string.Empty;
            //Act
            var result = memberValidator.ValidateMemberEmail(email).Result;

            //Asert
            Assert.That(!result.IsValid);
        }

        [Test]
        public void ValidateMembeName_WhenMemberHasEmptyName()
        {
            string name = string.Empty;
            //Act
            var result = memberValidator.ValidateMemberName(name).Result;

            //Asert
            Assert.That(!result.IsValid);
        }

        [Test]
        public void ValidateMembeName_WhenMemberHasName()
        {
            string name = "LoyaltyPrime";
            //Act
            var result = memberValidator.ValidateMemberName(name).Result;

            //Asert
            Assert.That(result.IsValid);
        }
    }
}
