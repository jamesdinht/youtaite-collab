using Collab.API.Models;
using Collab.API.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Collab.API.BLL
{
    public class RoleRepository : ARepository<Role>
    {
        protected override DbSet<Role> DbSet
        {
            get
            {
                return context.Roles;
            }
        }

        public RoleRepository(CollabContext context)
            : base(context)
        { }   
    }
}