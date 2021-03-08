using LoyaltyPrime.Data.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data;


namespace LoyaltyPrime.Service.Interfaces
{
    public interface ILoyaltyPrimeDBEntities: IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        IDbConnection GetDbContextConnection();
        DatabaseFacade Database { get; }

        DbSet<Member> Member { get; set; }
    }
}
