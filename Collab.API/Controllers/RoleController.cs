using Collab.API.DAL;
using Collab.API.Models;

namespace Collab.API.Controllers
{
    public class RoleController : AController<Role>
    {
        public RoleController(IRepository<Role> db)
            : base(db)
        { }
    }
}