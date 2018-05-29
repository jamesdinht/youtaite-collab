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
    /// <typeparam name="TEntity">A data entity.</typeparam>
    public abstract class ARepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly CollabContext db;

        protected ARepository(CollabContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Creates an entity and adds it to the database.
        /// </summary>
        /// <param name="entity">Entity to be created.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">UpdatedEntity is null.</exception>
        public virtual async Task CreateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await GetDbSet().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all the entities of a data set.
        /// </summary>
        /// <returns>A collection of entities.</returns>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await GetDbSet().AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves an entity with the specified ID.
        /// </summary>
        /// <param name="id">ID of the entity to retrieve.</param>
        /// <returns>Entity with matching ID.</returns>
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await GetDbSet().AsNoTracking().FirstOrDefaultAsync(entity => id == entity.Id);
        }

        /// <summary>
        /// Updates an entity with the specified ID.
        /// </summary>
        /// <param name="id">ID of the entity to update.</param>
        /// <param name="updatedEntity">The updated entity.</param>
        /// <returns>True if successful, false if not.</returns>
        /// <exception cref="System.ArgumentNullException">UpdatedEntity is null.</exception>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">No entity with matching ID is found.</exception>
        /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateException">An error is encountered while saving to the database.</exception>
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
            catch (DbUpdateException)
            {
                throw;
            }
            
            return rowsAffected > 0;
        }
        
        /// <summary>
        /// Deletes an entity with the specified ID.
        /// </summary>
        /// <param name="id">ID of the entity to delete.</param>
        /// <returns>True if successful, false if not</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">No entity with matching ID is found.</exception>
        /// 
        public virtual async Task<bool> DeleteAsync(int id)
        {
            TEntity entityToDelete = await GetDbSet().AsNoTracking().FirstOrDefaultAsync(entity => id == entity.Id);
            if (entityToDelete == null)
            {
                throw new KeyNotFoundException(IncorrectKeyMessage(id));
            }

            GetDbSet().Remove(entityToDelete);
            int rowsAffected = await db.SaveChangesAsync();

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