namespace Posterr.Domain
{
    public class Post :EntityBase
    {
        public string Content { get; set; } = string.Empty;

        public bool IsOriginal
        {
            get { return !IsRepost && !IsQuote; }
        }

        public bool IsRepost 
        {
            get { return RepostedPost is not null || RepostedPostId is not null; }
        }

        public Guid? RepostedPostId { get; set; }
        public Post? RepostedPost { get; set; }

        public bool IsQuote
        {
            get { return IsRepost && !String.IsNullOrEmpty(Content); }
        }

        public Guid UserId { get; set; }
        public User? Owner { get; set; }
    }
}