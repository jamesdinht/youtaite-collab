using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collab.API.DAL;
using Collab.API.Models;
using Collab.API.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Collab.API.BLL
{
    public class GroupRepository : ARepository<Group>
    {
        public GroupRepository(CollabContext db)
            : base(db)
        { }
    }
}