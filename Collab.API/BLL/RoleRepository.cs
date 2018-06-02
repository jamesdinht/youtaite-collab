using Collab.API.Models;
using Collab.API.Models.Context;

namespace Collab.API.BLL
{
    public class RoleRepository : ARepository<Role>
    {
        public RoleRepository(CollabContext db)
            : base(db)
        { }
    }
}