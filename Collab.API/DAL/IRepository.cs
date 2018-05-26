using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collab.API.Models;

namespace Collab.API.DAL
{
    /// <summary>
    /// Generic repository for the application. Defines basic async CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">Any object that inherits from BaseModel</typeparam>
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        /// <summary>
        /// Adds an entity to the database.
        /// </summary>
        /// <param name="entity">Entity to be added.</param>
        /// <returns></returns>
        Task CreateAsync(TEntity entity);

        /// <summary>
        /// Updates an entity in the database.
        /// </summary>
        /// <param name="id">ID of the entity to be updated.</param>
        /// <param name="entity">An updated entity.</param>
        /// <returns>True if successful, false if not.</returns>
        Task<bool> UpdateAsync(int id, TEntity updatedEntity);

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="id">ID of the entity to be deleted.</param>
        /// <returns>True if successful, false if not.</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Retrieves all the entities from the database.
        /// </summary>
        /// <returns>All the entities in the database.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Retrieves an entity from the database.
        /// </summary>
        /// <param name="id">ID of the entity to retrieve.</param>
        /// <returns>An entity with matching ID.</returns>
        Task<TEntity> GetByIdAsync(int id);
    }
}