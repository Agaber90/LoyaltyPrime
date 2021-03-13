using LoyaltyPrime.Data.Enities;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account> GetAccountById(long accountID);
        Task<IQueryable<Account>> GetAccountByMemberId(long memberID );

        Task<IQueryable<Account>> GetAccounts();
    }
}
