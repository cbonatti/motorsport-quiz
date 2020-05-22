using Microsoft.EntityFrameworkCore;
using MotorsportQuiz.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportQuiz.Infra.Data
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {

        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public RepositoryAsync(MotorsportQuizDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            var entityEntry = await dbSet.AddAsync(obj);
            await CommitAsync();
            return entityEntry.Entity;
        }

        public virtual async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return await CommitAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(dbSet);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> RemoveAsync(object id)
        {
            TEntity entity = await GetByIdAsync(id);

            if (entity == null) return false;

            return await RemoveAsync(entity) > 0 ? true : false;
        }

        public virtual async Task<int> RemoveAsync(TEntity obj)
        {
            dbSet.Remove(obj);
            return await CommitAsync();
        }

        public virtual async Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
            return await CommitAsync();
        }

        public virtual async Task<int> UpdateAsync(TEntity obj)
        {
            dbContext.Entry(obj).State = EntityState.Modified;
            return await CommitAsync();
        }

        public virtual async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
            return await CommitAsync();
        }

        private async Task<int> CommitAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
