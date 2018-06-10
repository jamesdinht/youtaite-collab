using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collab.API.DAL;
using Collab.API.Models;

namespace Collab.API.Controllers
{
    public class UsersController : AController<User>
    {
        public UsersController(IRepository<User> db) : base(db)
        { }    
    }
}