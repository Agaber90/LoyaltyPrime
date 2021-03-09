

using LoyaltyPrime.Ground;
using System.Collections.Generic;

namespace LoyaltyPrime.Service.Model
{
    public interface IServiceResult<T> where T : class
    {
        List<string> Messages { get; set; }
        bool IsValid { get; set; }
        ValidationStatus? Status { get; set; }
    }
    public class ServiceResultDetail<T> : IServiceResult<T> where T : class
    {
        public ServiceResultDetail()
        {
            IsValid = true;
            Messages = new List<string>();
        }
        public T Model { get; set; }
        public List<string> Messages { get; set; }
        public bool IsValid { get; set; }
        public long SubTotalCount { get; set; }
        public ValidationStatus? Status { get; set; }
    }

}
