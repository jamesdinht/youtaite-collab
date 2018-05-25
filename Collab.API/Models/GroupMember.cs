namespace Collab.API.Models
{
    /// <summary>
    /// Data entity representing the joint table between Group and User.
    /// </summary>
    public class GroupMember : BaseModel
    {
        // Foreign key User
        public int UserId { get; set; }
        public virtual User User { get; set; }

        // Foreign key Group
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}