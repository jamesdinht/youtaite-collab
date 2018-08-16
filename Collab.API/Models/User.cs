using System;
using System.Collections.Generic;

namespace Collab.API.Models
{
    /// <summary>
    /// Data entity representing a User of the application.
    /// </summary>
    public class User : BaseModel
    {
        public string Nickname { get; set; }

        public string EmailAddress { get; set; }

        public virtual ICollection<GroupMember> Groups { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
    }
}