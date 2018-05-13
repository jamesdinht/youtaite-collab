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
    public class UserRepository : IRepository<User>
    {
        private readonly CollabContext db;

        public UserRepository(CollabContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            await db.AddAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await db.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await db.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<bool> UpdateAsync(int id, User updatedUser)
        {
            if (updatedUser == null)
            {
                throw new ArgumentNullException(nameof(updatedUser));
            }

            User userToBeUpdated = await db.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);
            if (userToBeUpdated == null)
            {
                throw new KeyNotFoundException($"A user with id: {id} could not be found.");
            }

            db.Entry(updatedUser).State = EntityState.Modified;
            int rowsAffected = await db.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            User userToBeDeleted = await db.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);
            if (userToBeDeleted == null)
            {
                throw new KeyNotFoundException($"A user with id: {id}, could not be found.");
            }

            db.Users.Remove(userToBeDeleted);
            int rowsAffected = await db.SaveChangesAsync();

            return rowsAffected > 0;
        }
    }
}