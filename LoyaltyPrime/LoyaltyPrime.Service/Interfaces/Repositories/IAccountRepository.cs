using LoyaltyPrime.Data.Enities;
using LoyaltyPrime.DTO.Models;
using System.Linq;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces.Repositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account> GetAccountById(long accountID);
        Task<IQueryable<Account>> GetAccountByMemberId(long memberID);

        Task<IQueryable<Account>> GetAccounts();

        Task<IQueryable<Account>> GetActiveAccounts(long memberID);

        Task<bool> UpdateRedeemeddAccounts(DTORedeemPoint dTORedeemPoint)
    }
}
