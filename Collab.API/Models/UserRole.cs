namespace Collab.API.Models
{
    /// <summary>
    /// Data entity representing the joint table of Users and Roles.
    /// </summary>
    public class UserRole : BaseModel
    {
        // Foreign Key User
        public int UserId { get; set; }
        public virtual User User { get; set; }

        // Foreign Key Role
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}