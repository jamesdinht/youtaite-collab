using Collab.API.Models;
using Collab.API.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Collab.API.BLL
{
    /// <summary>
    /// Concrete repository for Projects
    /// </summary>
    /// <typeparam name="Project">A project, typically worked on by one Group.</typeparam>
    public class ProjectRepository : ARepository<Project>
    {
        protected override DbSet<Project> DbSet
        {
            get
            {
                return context.Projects;
            }    
        }
        
        public ProjectRepository(CollabContext context)
            : base(context)
        { }
    }
}