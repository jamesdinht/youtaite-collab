using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collab.API.Models
{
    /// <summary>
    /// Data entity representing a Group, or a collection of Users.
    /// </summary>
    public class Group : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<GroupMember> Users { get; set; }
    }
}