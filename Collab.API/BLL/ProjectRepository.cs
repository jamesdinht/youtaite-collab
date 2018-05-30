using Collab.API.Models;
using Collab.API.Models.Context;

namespace Collab.API.BLL
{
    /// <summary>
    /// Concrete repository for Projects
    /// </summary>
    /// <typeparam name="Project">A project, typically worked on by one Group.</typeparam>
    public class ProjectRepository : ARepository<Project>
    {
        public ProjectRepository(CollabContext db)
            : base(db)
        { }
    }
}