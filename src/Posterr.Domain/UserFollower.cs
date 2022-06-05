namespace Posterr.Domain
{
    public class UserFollower
    {
        public Guid FollowerId { get; internal set; }
        public User? Follower { get; internal set; }

        public Guid FollowedId { get; internal set; }
        public User? Followed { get; internal set; }

        public UserFollower() {}

        public UserFollower(User follower, User followed)
        {
            FollowerId = follower.Id;
            Follower = follower;
            FollowedId = followed.Id;
            Followed = followed;
        }

    }
}
