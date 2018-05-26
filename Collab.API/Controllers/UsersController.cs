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
    public class UsersController : AController<User>
    {
        public UsersController(IRepository<User> _db) : base(_db)
        { }    
    }
}