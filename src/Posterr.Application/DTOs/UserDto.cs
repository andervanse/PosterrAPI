namespace Posterr.Application.DTOs
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;
        public UserSummaryDto? Summary { get; set; }
        public UserPostsPerDayDto? TodayPosts { get; set; }
        public IEnumerable<PostDto>? Posts { get; set; }
    }
}
