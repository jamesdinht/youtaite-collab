using Collab.API.DAL;
using Collab.API.Models;

namespace Collab.API.Controllers
{
    public class RolesController : AController<Role>
    {
        public RolesController(IRepository<Role> db)
            : base(db)
        { }
    }
}