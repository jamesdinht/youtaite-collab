using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collab.API.Models
{
    public class Group : BaseModel
    {
        public string Name { get; set; }

        public int ProjectId { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<GroupMember> Users { get; set; }
    }
}