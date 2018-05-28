using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Collab.API.DAL;
using Collab.API.Models;
using Collab.API.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Collab.API.BLL
{
    /// <summary>
    /// Concrete implementation for Users.
    /// </summary>
    /// <typeparam name="User">A user of the application.</typeparam>
    public class UserRepository : ARepository<User>
    {
        public UserRepository(CollabContext db)
            : base (db)
        { }

        public async override Task CreateAsync(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await db.Users.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async override Task<bool> UpdateAsync(int id, User updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ArgumentNullException(nameof(updatedEntity));
            }

            User userToBeUpdated = await db.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);
            if (userToBeUpdated == null)
            {
                throw new KeyNotFoundException(IncorrectKeyMessage(id, nameof(User)));
            }

            db.Entry(updatedEntity).State = EntityState.Modified;
            int rowsAffected = await db.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public async override Task<bool> DeleteAsync(int id)
        {
            User userToBeDeleted = await db.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);
            if (userToBeDeleted == null)
            {
                throw new KeyNotFoundException(IncorrectKeyMessage(id, nameof(User)));
            }

            db.Users.Remove(userToBeDeleted);
            int rowsAffected = await db.SaveChangesAsync();

            return rowsAffected > 0;
        }
    }
}