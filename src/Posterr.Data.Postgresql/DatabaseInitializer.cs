using Microsoft.EntityFrameworkCore;
using Posterr.Domain;

namespace Posterr.Repository.Postgresql
{
    public static class DatabaseInitializer 
    {
        public static bool Seed(PosterrDbContext context)
        {

            if (context.Users is not null && !context.Users.Any())
            {
                User[] users = GenerateUsers();
                Post[] posts = GeneratePosts();

                for (int i = 0; i < posts.Length; i += 6)
                {
                    users[0].PublishPost(posts[i + 0]);
                    users[1].PublishPost(posts[i + 1]);
                    users[2].PublishPost(posts[i + 2]);
                    users[3].PublishPost(posts[i + 3]);
                    users[4].PublishPost(posts[i + 4]);
                    users[5].PublishPost(posts[i + 5]);
                }

                InsertRepostedPosts(users, posts);

                context.AddRange(users);
                context.SaveChanges();
                InsertFollowingUsers(users);
                context.SaveChanges();
            }

            return true;
        }

        private static User[] GenerateUsers()
        {
            return new List<User>
                {
                    new User { Name = "JettCummings" },
                    new User { Name = "AmarBarlow" },
                    new User { Name = "KeonDraper" },
                    new User { Name = "DiyaCharles" },
                    new User { Name = "HusnaLogan" },
                    new User { Name = "MaryamLi" }
                }.ToArray();
        }

        private static Post[] GeneratePosts()
        {

            return new List<String>
                {
                    "Be yourself; everyone else is already taken.",
                    "Two things are infinite: the universe and human stupidity; and I'm not sure about the universe.",
                    "So many books, so little time.",
                    "A room without books is like a body without a soul.",
                    "You know you're in love when you can't fall asleep because reality is finally better than your dreams.",
                    "You only live once, but if you do it right, once is enough.",
                    "Be the change that you wish to see in the world.",
                    "In three words I can sum up everything I've learned about life: it goes on.",
                    "If you want to know what a man's like, take a good look at how he treats his inferiors, not his equals.",
                    "If you tell the truth, you don't have to remember anything.",
                    "Friendship ... is born at the moment when one man says to another What! You too? I thought that no one but myself . . .",
                    "A friend is someone who knows all about you and still loves you.",
                    "Always forgive your enemies; nothing annoys them so much.",
                    "Live as if you were to die tomorrow. Learn as if you were to live forever.",
                    "Darkness cannot drive out darkness: only light can do that. Hate cannot drive out hate: only love can do that.",
                    "We accept the love we think we deserve.",
                    "Without music, life would be a mistake.",
                    "I am so clever that sometimes I don't understand a single word of what I am saying.",
                    "To be yourself in a world that is constantly trying to make you something else is the greatest accomplishment.",
                    "It is better to be hated for what you are than to be loved for what you are not.",
                    "Good friends, good books, and a sleepy conscience: this is the ideal life.",
                    "We are all in the gutter, but some of us are looking at the stars.",
                    "Fairy tales are more than true: not because they tell us that dragons exist, but because they tell us that dragons can be beaten.",
                    "The fool doth think he is wise, but the wise man knows himself to be a fool.",
                    "It is better to remain silent at the risk of being thought a fool, than to talk and remove all doubt of it.",
                    "Life is what happens to us while we are making other plans.",
                    "Yesterday is history, tomorrow is a mystery, today is a gift of God, which is why we call it the present.",
                    "I have not failed. I've just found 10,000 ways that won't work.",
                    "It is not a lack of love, but a lack of friendship that makes unhappy marriages.",
                    "A woman is like a tea bag; you never know how strong it is until it's in hot water."
                }.Select(x => new Post 
                { 
                    Content = x 
                }).ToArray();
        }

        private static void InsertFollowingUsers(User[] users)
        {
            users[0].AddFollower(users[1]);
            users[0].AddFollower(users[2]);
            users[1].AddFollower(users[0]);
            users[1].AddFollower(users[2]);
            users[2].AddFollower(users[0]);
            users[2].AddFollower(users[1]);
        }

        private static void InsertRepostedPosts(User[] users, Post[] posts)
        {
            users[0].PublishPost(new Post
            {
                Content = "I loved it!",
                RepostedPostId = posts[4].Id,
                RepostedPost = posts[4],
            });

            users[1].PublishPost(new Post
            {
                Content = "I don't agree but I respect who thinks this way.",
                RepostedPostId = posts[3].Id,
                RepostedPost = posts[3],
            });

            users[2].PublishPost(new Post
            {
                Content = String.Empty,
                RepostedPostId = posts[2].Id,
                RepostedPost = posts[2],
            });

            users[1].PublishPost(new Post
            {
                Content = String.Empty,
                RepostedPostId = posts[1].Id,
                RepostedPost = posts[1],
            });
        }
    }
}
