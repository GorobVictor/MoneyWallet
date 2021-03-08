using Entity.Interface;
using Entity.Model;
using Entity.Model.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Controller
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : Base
    {
        internal MoneyWalletContext Context { get; }

        bool Disposed { get; set; }

        protected BaseRepository(MoneyWalletContext context)
        {
            this.Context = context;

            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            Context.ChangeTracker.LazyLoadingEnabled = false;

            Context.ChangeTracker.Clear();

        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<TEntity>> AddAsync(List<TEntity> entity)
        {
            Context.Set<TEntity>().AddRange(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> GetFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(List<TEntity> entities)
        {
            Context.ChangeTracker.Clear();

            Context.UpdateRange(entities);

            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.DisposeObject(true);
            GC.SuppressFinalize(this);
        }

        protected void DisposeObject(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                }

                this.Disposed = true;
            }
        }
    }
}
