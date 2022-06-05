namespace Posterr.Application.DTOs
{
    public class UserFollowerDto
    {
        public Guid UserFollowerId { get; set; }
        public Guid UserFollowedId { get; set; }
    }
}
