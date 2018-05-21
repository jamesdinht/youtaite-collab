using System.Collections.Generic;

namespace Collab.API.Models
{
    public enum RoleEnum {
        Animator, Artist, Mixer, Vocalist
    }

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