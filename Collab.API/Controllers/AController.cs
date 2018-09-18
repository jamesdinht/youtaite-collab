using System.Collections.Generic;
using System.Threading.Tasks;
using Collab.API.DAL;
using Collab.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Collab.API.Controllers
{
    /// <summary>
    /// Abstract controller. Contains all the common logic between the controllers.
    /// </summary>
    /// <typeparam name="TEntity">A data entity.</typeparam>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public abstract class AController<TEntity> : ControllerBase where TEntity : BaseModel
    {
        protected readonly IRepository<TEntity> db;

        public AController(IRepository<TEntity> db)
        {
            this.db = db;
        }

        // GET api/[entities]
        [HttpGet]
        [ProducesResponseType(200)]
        public virtual async Task<IActionResult> Get()
        {
            IEnumerable<TEntity> entities = await db.GetAllAsync();
            return Ok(entities);
        }

        // GET api/[entities]/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public virtual async Task<ActionResult<TEntity>> GetById(int id)
        {
            TEntity retrievedEntity = await db.GetByIdAsync(id);
            if (retrievedEntity == null)
            {
                return NotFound();
            } 

            return retrievedEntity;
        }

        // POST api/[entities]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public virtual async Task<ActionResult> Post([FromBody]TEntity entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            else
            {
                await db.CreateAsync(entity);
                return CreatedAtAction("Get", new { id = entity.Id }, entity);
            }
        
        }

        // PUT api/[entities]/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public virtual async Task<ActionResult> Put(int id, [FromBody]TEntity entity)
        {
            TEntity entityToBeUpdated = await db.GetByIdAsync(id);
            if (entityToBeUpdated == null)
            {
                return NotFound();
            }
            
            if (await db.UpdateAsync(id, entity))
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
        public virtual async Task<ActionResult> Delete(int id)
        {
            TEntity entityToBeDeleted = await db.GetByIdAsync(id);
            if (entityToBeDeleted == null)
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