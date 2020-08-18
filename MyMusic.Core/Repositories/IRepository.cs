using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Core.Repositories
{
   public interface IRepository<TEntity> where TEntity : class
   {
        Task<TEntity> GetByIdAsync(int Id);
        Task<bool> IsValid(Expression<Func<TEntity, bool>> predicate);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingeOrDeafaultAsync(Expression<Func<TEntity,bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeEntity(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
   }
}
