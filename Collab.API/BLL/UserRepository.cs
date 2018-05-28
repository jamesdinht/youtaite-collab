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
    /// <summary>
    /// Concrete implementation for Users.
    /// </summary>
    /// <typeparam name="User">A user of the application.</typeparam>
    public class UserRepository : ARepository<User>
    {
        public UserRepository(CollabContext db)
            : base (db)
        { }
    }
}