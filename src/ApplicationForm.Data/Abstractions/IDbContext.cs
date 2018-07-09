using ApplicationForm.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationForm.Data.Abstractions
{
    /// <summary>
    /// Resolving a DbContext as an interface.
    /// </summary>
    public interface IDbContext : IDisposable
    {
        DbSet<Sector> Sectors { get; set; }

        DbSet<User> Users { get; set; }

        EntityEntry Attach(object entity);

        void AttachRange(IEnumerable<object> entities);
        
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        EntityEntry Entry(object entity);

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
