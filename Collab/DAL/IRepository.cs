using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collab.Models;

namespace Collab.DAL
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        Task CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(int id, TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
    }
}