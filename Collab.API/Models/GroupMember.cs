namespace Collab.API.Models
{
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