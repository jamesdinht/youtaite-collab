using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collab.API.DAL;
using Collab.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Collab.API.Controllers
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
            IEnumerable<User> users = await db.GetAllAsync();
            return Ok(users);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            User retrievedUser = await db.GetByIdAsync(id);
            if (retrievedUser == null)
            {
                return NotFound();
            } 

            return Ok(retrievedUser);
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
            else
            {
                if (user == null)
                {
                    return BadRequest();
                }
                else
                {
                    await db.CreateAsync(user);
                    return CreatedAtAction("Get", new { id = user.Id }, user);
                }
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody]User user)
        {
            User userToBeUpdated = await db.GetByIdAsync(id);
            if (userToBeUpdated == null)
            {
                return NotFound();
            }
            
            if (await db.UpdateAsync(id, user))
            {
                return NoContent();
            } else
            {
                return BadRequest();
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            User userToBeDeleted = await db.GetByIdAsync(id);
            if (userToBeDeleted == null)
            {
                return NotFound();
            }
            if (await db.DeleteAsync(id))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }        
    }
}