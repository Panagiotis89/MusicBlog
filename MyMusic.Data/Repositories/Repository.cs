using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //protected is for those classes who are going to derive from Resository
        protected readonly DbContext _dbContext;
        public Repository(DbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task AddAsync(TEntity entity)
        {
           await  _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeEntity(IEnumerable<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(int Id)
        {
            return _dbContext.Set<TEntity>().FindAsync(Id).AsTask();
        }

        public Task<bool> IsValid(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().AnyAsync(predicate);
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingeOrDeafaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
          return  _dbContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }
    }
}
