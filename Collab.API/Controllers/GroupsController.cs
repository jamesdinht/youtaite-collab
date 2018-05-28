using Collab.API.DAL;
using Collab.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Collab.API.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : AController<Group>
    {
        public GroupsController(IRepository<Group> db) : base(db)
        { }
    }
}