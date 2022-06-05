namespace Posterr.Application.DTOs
{
    public class CreatePostDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid? RepostedPostId { get; set; }
        public Guid UserOwnerId { get; set; }
    }
}