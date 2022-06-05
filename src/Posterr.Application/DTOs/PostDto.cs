namespace Posterr.Application.DTOs
{
    public class PostDto
    {
        public string Content { get; set; } = string.Empty;
        public bool IsOriginal { get; set; }
        public bool IsRepost { get; set; }
        public Guid? RepostedPostId { get; set; }
        public PostDto? RepostedPost { get; set; }
        public bool IsQuote { get; set; }
        public Guid UserId { get; set; }
        public UserDto? Owner { get; set; }
    }
}