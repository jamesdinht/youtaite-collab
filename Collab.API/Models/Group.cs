using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Collab.API.Models
{
    public class Group : BaseModel
    {
        public string Name { get; set; }

        public ICollection<GroupMember> Users { get; set; }
    }
}