using Core.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interface
{
    public interface IBaseRepository<TEntity>
        where TEntity : Base
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddAsync(List<TEntity> entity);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task UpdateAsync(List<TEntity> entities);
    }
}
