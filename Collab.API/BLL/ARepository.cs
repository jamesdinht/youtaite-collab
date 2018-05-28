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

        public virtual async Task CreateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            await GetDbSet().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public abstract Task<bool> DeleteAsync(int id);
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await GetDbSet().AsNoTracking().ToListAsync();
        }
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await GetDbSet().AsNoTracking().FirstOrDefaultAsync(entity => id == entity.Id);
        }
        public virtual async Task<bool> UpdateAsync(int id, TEntity updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ArgumentNullException(nameof(updatedEntity));
            }

            TEntity entityToUpdate = await GetDbSet().AsNoTracking().FirstOrDefaultAsync(entity => id == entity.Id);
            if (entityToUpdate == null)
            {
                throw new KeyNotFoundException(IncorrectKeyMessage(id));
            }

            db.Entry(updatedEntity).State = EntityState.Modified;
            int rowsAffected = 0;
            try 
            {
                rowsAffected = await db.SaveChangesAsync();
            }
            catch (DbUpdateException dbue)
            {
                throw dbue;
            }
            
            return rowsAffected > 0;
        }

        protected string IncorrectKeyMessage(int id)
        {
            return $"{typeof(TEntity).Name} with id: {id} does not exist.";
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