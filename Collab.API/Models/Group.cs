using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collab.API.Models
{
    public class Group : BaseModel
    {
        public string Name { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public virtual ICollection<GroupMember> Users { get; set; }
    }
}