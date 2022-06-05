using Microsoft.EntityFrameworkCore;
using Posterr.Domain;
using Posterr.Repository.Postgresql.Mappings;

namespace Posterr.Repository.Postgresql
{
    public class PosterrDbContext : DbContext
    {
        public PosterrDbContext(DbContextOptions options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSummary> UserSummary { get; set; }
        public virtual DbSet<UserPostsPerDay> UserPostsPerDay { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<UserFollower> UserFollowers { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await this.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}