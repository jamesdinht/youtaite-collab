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
        public UsersController(IRepository<User> db)
        {
            this.db = db;
        }

        // GET api/users
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await db.GetAllAsync());
        }

        // GET api/users/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid id)
        {
            User retrievedUser = await db.GetByIdAsync(id);
            if (db.GetByIdAsync(id) == null)
            {
                return NotFound();
            } 

            return Ok(await db.GetByIdAsync(id));
        }

        // POST api/users
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.CreateAsync(user);
            return CreatedAtAction(nameof(db.GetByIdAsync), new { id = user.Id }, user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(Guid id, [FromBody]User user)
        {
            User userToBeUpdated = await db.GetByIdAsync(id);
            if (userToBeUpdated == null)
            {
                return NotFound();
            }
            
            if (await db.UpdateAsync(id, user))
            {
                return Ok(true);
            } else
            {
                return BadRequest();
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(Guid id)
        {
            User userToBeDeleted = await db.GetByIdAsync(id);
            if (userToBeDeleted == null)
            {
                return BadRequest();
            }
            return Ok(await db.DeleteAsync(id));
        }        
    }
}