using LoyaltyPrime.Data;
using LoyaltyPrime.Data.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace LoyaltyPrime.Service.Interfaces
{
    public interface ILoyaltyPrimeDBEntities : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        bool IsChangesExists();
        IDbConnection GetDbContextConnection();
        DatabaseFacade Database { get; }

        DbSet<Member> Member { get; set; }
        DbSet<Account> Account { get; set; }
    }
}
