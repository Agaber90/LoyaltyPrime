using LoyaltyPrime.Service.Interfaces;
using LoyaltyPrime.Service.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LoyaltyPrime.Presistance.CoreImplementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ILoyaltyPrimeDBEntities _context;
        public BaseRepository(ILoyaltyPrimeDBEntities context)
        {
            _context = context;
        }
        private ILoyaltyPrimeDBEntities LoyaltyPrimeEntities => _context;
        public async Task Create(T t)
        {
            LoyaltyPrimeEntities.Set<T>().Add(t);
        }

        public async Task Create(List<T> t)
        {
            LoyaltyPrimeEntities.Set<T>().AddRange(t);
        }

        public async Task<bool> EnsureSaveChangesAsync()
        {
            return await LoyaltyPrimeEntities.SaveChangesAsync() > 0;
        }

        public async Task<IQueryable<T>> FindAll()
        {
            return LoyaltyPrimeEntities.Set<T>();
        }

        public async Task<T> FindById(Expression<Func<T, bool>> predicate)
        {
            return LoyaltyPrimeEntities.Set<T>().FirstOrDefault(predicate);
        }

        public async Task Remove(T t)
        {
            LoyaltyPrimeEntities.Set<T>().Remove(t);
        }

        public async Task Remove(List<T> t)
        {
            LoyaltyPrimeEntities.Set<T>().RemoveRange(t);
        }

        public async Task<bool> SaveChangesAsync()
        {
            int changes = await LoyaltyPrimeEntities.SaveChangesAsync();

            return changes > 0 ? true
                : (LoyaltyPrimeEntities.IsChangesExists() ? changes > 0 : changes >= 0);
        }

        public async Task<IQueryable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return LoyaltyPrimeEntities.Set<T>().Where(predicate).AsQueryable();
        }
    }
}
