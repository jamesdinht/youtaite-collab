using Collab.API.DAL;
using Collab.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Collab.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : AController<Project>
    {
        public ProjectController(IRepository<Project> db)
            : base(db)
        { }
    }
}