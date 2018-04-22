using System.Collections.Generic;
using Collab.DAL;
using Collab.Models;

namespace Collab.BLL
{
    public class UserRepository : IRepository<User>
    {
        private readonly CollabContext db;

        public UserRepository(CollabContext db) {
            this.db = db;
        }

        public void Create(User user)
        {
            
        }

        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(string id, User user)
        {
            throw new System.NotImplementedException();
        }
    }
}