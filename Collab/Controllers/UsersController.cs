using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collab.DAL;
using Collab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Collab.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IRepository<User> db;

        // Constructor dependency injection
        public UsersController(IRepository<User> db) {
            this.db = db;
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.GetAll();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return db.GetById(id);
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody]User user)
        {
            db.Create(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public bool Put(string id, [FromBody]User user)
        {
            return db.Update(id, user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(string id)
        {
            return db.Delete(id);
        }        
    }
}