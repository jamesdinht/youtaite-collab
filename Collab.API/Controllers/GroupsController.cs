using Collab.API.DAL;
using Collab.API.Models;

namespace Collab.API.Controllers
{
    public class GroupsController : AController<Group>
    {
        public GroupsController(IRepository<Group> db) : base(db)
        { }
    }
}