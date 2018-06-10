using Collab.API.DAL;
using Collab.API.Models;

namespace Collab.API.Controllers
{
    public class ProjectsController : AController<Project>
    {
        public ProjectsController(IRepository<Project> db)
            : base(db)
        { }
    }
}