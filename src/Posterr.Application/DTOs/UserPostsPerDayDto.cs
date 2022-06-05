namespace Posterr.Application.DTOs
{
    public class UserPostsPerDayDto
    {
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
    }
}