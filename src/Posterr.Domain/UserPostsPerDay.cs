namespace Posterr.Domain
{
    public class UserPostsPerDay
    {
        public UserPostsPerDay()
        {
        }

        public UserPostsPerDay(User user)
        {
            UserId = user.Id;
            UpdatedAt = DateTime.Now;
        }

        public Guid? UserId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Quantity { get; set; }
    }
}