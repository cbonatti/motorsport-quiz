using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportQuiz.Infra.Data.Interfaces
{
    public interface IRepositoryAsync<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity obj);
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<int> UpdateAsync(TEntity obj);
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities);

        Task<bool> RemoveAsync(object id);
        Task<int> RemoveAsync(TEntity obj);
        Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
