using Microsoft.EntityFrameworkCore;

namespace Posterr.Repository.Postgresql.Test
{
    public class DbContextTest
    {
        [Fact(DisplayName = "Database connection should be OK.")]
        public void GivenDbContext_WhenConnects_ThenShouldBeOK()
        {
            PosterrContextFactory factory = new PosterrContextFactory();
            using var context = factory.CreateDbContext(new string[] { });
            context.Database.Migrate();
            var canConnect = context.Database.CanConnect();
            Assert.True(canConnect);
        }

        [Fact(DisplayName = "Database Seed execution should be OK.")]
        public void GivenDbContext_WhenSeeds_ThenShouldBeOK()
        {
            PosterrContextFactory factory = new PosterrContextFactory();
            using var context = factory.CreateDbContext(new string[] { });
            var connectSuccess = context.Database.CanConnect();
            context.Database.Migrate();
            var success = DatabaseInitializer.Seed(context);
            Assert.True(connectSuccess);
            Assert.True(success);
        }

        [Fact(DisplayName = "Show first 5 posts of the first user.")]
        public void GivenUser_WhenRetrievePosts_ThenShouldReturnFirst5Rows()
        {
            PosterrContextFactory factory = new PosterrContextFactory();
            using var context = factory.CreateDbContext(new string[] { });
            var userPosts = context.Users?
                                   .Include(u => u.Posts)?
                                   .FirstOrDefault()?
                                   .Posts
                                   .Skip(0)
                                   .Take(5);

            Assert.Equal(5, userPosts?.Count());
        }
    }
}