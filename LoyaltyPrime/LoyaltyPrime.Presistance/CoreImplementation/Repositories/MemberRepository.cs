using LoyaltyPrime.Data.Enities;
using LoyaltyPrime.Service.Interfaces;
using LoyaltyPrime.Service.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Presistance.CoreImplementation
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        protected readonly ILoyaltyPrimeDBEntities _loyaltyPrimeEntities;
        public MemberRepository(ILoyaltyPrimeDBEntities context) : base(context)
        {
            _loyaltyPrimeEntities = context;
        }
        protected ILoyaltyPrimeDBEntities LoyaltyPrimeEntities => _loyaltyPrimeEntities;

        /// <summary>
        /// Get Member by Id
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public async Task<Member> GetMemberById(int memberId)
        {
            var member = await LoyaltyPrimeEntities.Member.FirstOrDefaultAsync(a => a.Id == memberId);
            return member;
        }

        /// <summary>
        /// Get List of member
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<Member>> GetMembers()
        {
            var members = LoyaltyPrimeEntities.Member.AsQueryable();
            return members;

        }
    }
}
