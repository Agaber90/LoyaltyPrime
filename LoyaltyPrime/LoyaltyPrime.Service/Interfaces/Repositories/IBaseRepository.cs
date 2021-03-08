using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task Create(T t);
        Task Create(List<T> t);
        Task Remove(T t);
        Task Remove(List<T> t);
        Task<T> FindById(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> FindAll();
        Task<bool> SaveChangesAsync();
        Task<bool> EnsureSaveChangesAsync();
        Task<IQueryable<T>> Where(Expression<Func<T, bool>> predicate);
    }
}
