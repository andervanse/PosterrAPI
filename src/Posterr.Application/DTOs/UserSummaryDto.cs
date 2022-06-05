namespace Posterr.Application.DTOs
{
    public class UserSummaryDto
    {
        public Guid UserId { get; set; }
        public int NumberOfFollowers { get; set; }
        public int NumberOfFollowingUsers { get; set; }
        public int NumberOfPosts { get; set; }
    }
}