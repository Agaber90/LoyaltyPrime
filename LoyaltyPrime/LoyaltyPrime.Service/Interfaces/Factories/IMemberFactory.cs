using LoyaltyPrime.Data.Enities;
using LoyaltyPrime.DTO.Models;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces.Factories
{
    public interface IMemberFactory
    {
        Task<Member> CreateMember(DTOMember memberModel);
    }
}
