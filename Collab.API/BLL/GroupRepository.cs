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
    /// <summary>
    /// Concrete implementation for Groups.
    /// </summary>
    /// <typeparam name="Group">A group of users.</typeparam>
    public class GroupRepository : ARepository<Group>
    {
        protected override DbSet<Group> DbSet
        {
            get
            {
                return context.Groups;
            }
        }

        public GroupRepository(CollabContext context)
            : base(context)
        { }
    }
}