﻿using LoyaltyPrime.DTO.Models;
using LoyaltyPrime.Service.Interfaces.ServiceValidators;
using LoyaltyPrime.Service.Interfaces.Validators;
using LoyaltyPrime.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Implementation.ServiceValidators
{
    public class MemberServiceValidator : IMemberServiceValidator
    {
        private readonly Lazy<IMemberValidator> _memberValidator;
        public MemberServiceValidator(Lazy<IMemberValidator> memberValidator)
        {
            _memberValidator = memberValidator;
        }
        private IMemberValidator MemberValidator => _memberValidator.Value;
        public async Task<ValidatorResult> AddEditMemberValidator(DTOMember dTOMember)
        {
            var memberTasks = new List<Task<ValidatorResult>>()
            {
                MemberValidator.ValidateMemberName(dTOMember.Name),
                MemberValidator.ValidateMemberEmail(dTOMember.Email),
                MemberValidator.ValidateMemberEmailPattern(dTOMember.Email),
            };
            await Task.WhenAll(memberTasks);
            var taskResult = memberTasks.Select(a => a.Result).FirstOrDefault(a => !a.IsValid);
            if (taskResult != null) return taskResult;
            return new ValidatorResult();
        }
    }
}