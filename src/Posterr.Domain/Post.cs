namespace Posterr.Domain
{
    /// <summary>
    ///  Posts are the equivalent of Twitter's tweets. They are text only, user generated content. 
    ///  Users can write original posts and interact with other users' posts by reposting or quote-posting.
    ///    - Reposting: Users can repost other users' posts (like Twitter Retweet)
    ///    - Quote-post: Users can repost other user's posts and leave a comment along with it (like Twitter Quote Tweet)
    /// </summary>

    public class Post :EntityBase
    {
        public string Content { get; set; } = string.Empty;

        public bool IsOriginal
        {
            get { return !IsRepost && !IsQuote; }
        }

        public bool IsRepost 
        {
            get { return RepostedPost is not null; }
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