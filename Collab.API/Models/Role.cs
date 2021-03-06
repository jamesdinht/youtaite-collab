using System.Collections.Generic;

namespace Collab.API.Models
{
    /// <summary>
    /// Predefined user roles.
    /// </summary>
    public enum RoleEnum {
        Animator, Artist, Mixer, Vocalist
    }

    /// <summary>
    /// Data entity representing the Roles a User can be.
    /// </summary>
    public class Role : BaseModel
    {
        private Role(RoleEnum @enum)
        {
            Id = (int)@enum;
            RoleName = @enum.ToString();
        }

        protected Role() { }
        public string RoleName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public static implicit operator Role(RoleEnum @enum) => new Role(@enum);

        public static implicit operator RoleEnum(Role role) => (RoleEnum)role.Id;
    }
}