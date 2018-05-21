namespace Collab.API.Models
{
    public class Project : BaseModel
    {
        public string ProjectName { get; set; }

        public virtual Group Group { get; set; }
    }
}