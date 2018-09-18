using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Collab.API.BLL;
using Collab.API.DAL;
using Collab.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Collab.API.Controllers
{
    public class UsersController : AController<User>
    {
        public UsersController(IRepository<User> db) : base(db)
        { }

        [HttpGet("{email}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<User>> GetByEmail(string email)
        {
            if (!(db is UserRepository))
            {
                return BadRequest();
            }
            UserRepository userRepo = db as UserRepository;            
            User userToRetrieve = await userRepo.GetByEmail(email);

            if (userToRetrieve == null)
            {
                return NotFound();
            }

            return Ok(userToRetrieve);
        }
    }
}