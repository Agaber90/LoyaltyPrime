using LoyaltyPrime.Data.Enities;
using LoyaltyPrime.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace LoyaltyPrime.Presistance
{
    public class LoyaltyPrimeDBEntities : DbContext, ILoyaltyPrimeDBEntities
    {
        public LoyaltyPrimeDBEntities(DbContextOptions<LoyaltyPrimeDBEntities> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Member> Member { get; set; }

        public IDbConnection GetDbContextConnection()
        {
            var connection = Database.GetDbConnection();
            if (connection.State == ConnectionState.Open)
            {
                return connection;
            }
            connection.Open();
            return connection;
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
