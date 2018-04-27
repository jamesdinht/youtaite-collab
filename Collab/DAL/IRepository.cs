using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collab.Models;

namespace Collab.DAL
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        Task CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(Guid id, TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
    }
}