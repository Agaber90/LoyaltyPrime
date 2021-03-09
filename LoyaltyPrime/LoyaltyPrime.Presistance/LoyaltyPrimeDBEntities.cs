using LoyaltyPrime.Data;
using LoyaltyPrime.Data.Enities;
using LoyaltyPrime.Presistance.Extensions;
using LoyaltyPrime.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        public DbSet<Account> Account { get; set; }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.Entity<Member>().HasMany(a => a.Accounts).WithOne(a => a.Member);
        }
        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;
            foreach (var entry in this.ChangeTracker.Entries<IEntityTracker>())
            {
                var entity = entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.Createdate = entity.Updatedate = now;
                        break;
                    case EntityState.Modified:
                        entity.Updatedate = now;
                        break;
                }
            }
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;
            foreach (var entry in this.ChangeTracker.Entries<IEntityTracker>())
            {
                var entity = entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.Createdate = entity.Updatedate = now;
                        break;
                    case EntityState.Modified:
                        entity.Updatedate = now;
                        break;
                }
            }
            return await base.SaveChangesAsync();
        }
        public void Update<TEntity>(TEntity model) where TEntity : class, IEntity
        {
            var result = this.Set<TEntity>().SingleOrDefault(b => b.Id == model.Id);
            if (result != null)
            {
                this.Entry<TEntity>(result).CurrentValues.SetValues(model);
            }
        }
        public bool IsChangesExists()
        {
            return this.ChangeTracker.HasChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder
            .ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));
            base.OnConfiguring(optionsBuilder);
        }
        public bool GetLazyLoadingEnabledFlag()
        {
            return this.ChangeTracker.LazyLoadingEnabled;
        }
        public void SetLazyLoadingEnabledFlag(bool val)
        {
            this.ChangeTracker.LazyLoadingEnabled = val;
        }
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
    }
}
