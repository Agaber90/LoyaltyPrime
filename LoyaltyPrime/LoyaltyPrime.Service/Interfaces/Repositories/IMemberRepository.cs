using LoyaltyPrime.Data.Enities;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces.Repositories
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        Task<Member> GetMemberById(long memberId);
        Task<IQueryable<Member>> GetMembers();
    }
}
