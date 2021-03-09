using LoyaltyPrime.Ground;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoyaltyPrime.Service.Model
{
    public class ValidatorResult
    {
        public string Message { get; set; }
        public bool IsValid { get; set; }
        public ValidationStatus? Status { get; set; }
        public ValidatorResult()
        {
            IsValid = true;
            Message = string.Empty;
        }
    }

    public class ServiceValidatorResult
    {
        public ServiceValidatorResult()
        {
            IsValid = true;
            Messages = new List<string>();
        }
        public bool IsValid { get; set; }
        public List<string> Messages { get; set; }
        public ValidationStatus? Status { get; set; }
    }
}
