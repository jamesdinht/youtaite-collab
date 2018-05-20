using System.ComponentModel.DataAnnotations.Schema;

namespace Collab.API.Models
{
    public class Group : BaseModel
    {
        public string Name { get; set; }

        public string ProjectName { get; set; }

        public int CollaborationId { get; set; }
        public Collaboration Collaboration { get; set; }
    }
}