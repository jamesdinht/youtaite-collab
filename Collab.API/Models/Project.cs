namespace Collab.API.Models
{
    /// <summary>
    /// Data entity representing a Project.
    /// </summary>
    public class Project : BaseModel
    {
        public string Name { get; set; }
        
        // Foreign key Group
        public virtual Group Group { get; set; }
    }
}