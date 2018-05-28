using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collab.API.DAL;
using Collab.API.Models;
using Collab.API.Models.Context;
using Microsoft.EntityFrameworkCore;
using Humanizer;
using System.Reflection;

namespace Collab.API.BLL
{
    /// <summary>
    /// Abstract repository that defines common logic across all concrete repositories.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ARepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly CollabContext db;

        public ARepository(CollabContext db)
        {
            this.db = db;
        }

        public abstract Task CreateAsync(TEntity entity);
        public abstract Task<bool> DeleteAsync(int id);
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await GetDbSet().ToListAsync();
        }
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await GetDbSet().FirstOrDefaultAsync(entity => id == entity.Id);
        }
        public abstract Task<bool> UpdateAsync(int id, TEntity updatedEntity);

        protected string IncorrectKeyMessage(int id, string entity)
        {
            return $"{entity} with id: {id} does not exist.";
        }

        /// <summary>
        /// During runtime, returns the DbSet for the corresponding Repository
        /// </summary>
        /// <returns>The DbSet for the corresponding repository.</returns>
        private DbSet<TEntity> GetDbSet()
        {
            Type setType = typeof(TEntity);
            string setName = setType.Name.Pluralize();
            PropertyInfo set = db.GetType().GetProperty(setName);
            return set.GetValue(db, null) as DbSet<TEntity>;
        }
    }
}