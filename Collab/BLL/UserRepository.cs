using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collab.DAL;
using Collab.Models;

namespace Collab.BLL
{
    public class UserRepository : IRepository<User>
    {
        private readonly CollabContext db;

        public UserRepository(CollabContext db)
        {
            this.db = db;
        }

        public Task CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}