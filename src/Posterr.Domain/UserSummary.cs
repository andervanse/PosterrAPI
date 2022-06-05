namespace Posterr.Domain
{
    public class UserSummary
    {
        public UserSummary()
        {
        }

        public UserSummary(User user)
        {
            UserId = user.Id;
            UpdatedAt = DateTime.Now;
        }

        public Guid? UserId { get; set; }
        public DateTime UpdatedAt { get; private set; }
        public int NumberOfFollowers { get; private set; }
        public int NumberOfFollowingUsers { get; private set; }
        public int NumberOfPosts { get; private set; }

        public void IncreaseNumberOfPosts()
        {
            NumberOfPosts++;
            UpdatedAt = DateTime.Now;
        }

        public void IncreaseNumberOfFollowers()
        {
            NumberOfFollowers++;
            UpdatedAt = DateTime.Now;
        }

        public void DecreaseNumberOfFollowers()
        {
            NumberOfFollowers--;
            UpdatedAt = DateTime.Now;
        }
    }
}