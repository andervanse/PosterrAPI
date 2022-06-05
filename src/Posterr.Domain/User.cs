using Posterr.Domain.Interfaces;

namespace Posterr.Domain
{
    public class User : EntityBase, IAggregateRoot
    {
        private IList<Post> _posts;
        private IList<UserFollower> _followers;
        private readonly IList<UserFollower> _removedFollowers;

        public User()
        {
            Summary = new UserSummary(this);
            TodayPosts = new UserPostsPerDay(this);
            _posts = new List<Post>();
            _followers = new List<UserFollower>();
            _removedFollowers = new List<UserFollower>();
        }

        public string Name { get; set; } = string.Empty;
        public UserSummary Summary { get; internal set; }
        public UserPostsPerDay TodayPosts { get; internal set; }
        public IEnumerable<Post> Posts { get => _posts; internal set => _posts = value.ToList(); }
        public IEnumerable<UserFollower> Followers { get => _followers; internal set => _followers = value.ToList(); }     
        public IEnumerable<UserFollower> RemovedFollowers { get => _removedFollowers; }
        
        public void PublishPost(Post post)
        {
            if (post is not null && TodayPosts.Quantity <= 5)
            {
                post.Owner = this;
                _posts.Add(post);
                TodayPosts.Quantity++;
                Summary.IncreaseNumberOfPosts();
            }
        }

        public void AddFollower(User followerUser)
        {
            if (followerUser is not null)
            {
                if (followerUser.Id == this.Id)
                    return;
                
                var follower = new UserFollower(follower: followerUser, followed: this);
                _followers.Add(follower);
                Summary.IncreaseNumberOfFollowers();
            }
        }

        public void RemoveFollower(User followerToRemove)
        {
            if (followerToRemove is not null)
            {
                var follower = new UserFollower( follower: followerToRemove, followed: this);
                _followers.Remove(follower);
                _removedFollowers.Add(follower);
                Summary.DecreaseNumberOfFollowers();
            }
        }
    }
}
