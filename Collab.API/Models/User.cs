using System;
using System.Collections.Generic;

namespace Collab.API.Models
{
    public class User : BaseModel
    {
        public string Nickname { get; set; }

        public virtual ICollection<GroupMember> Groups { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
    }
}