using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posterr.Domain;

namespace Posterr.Repository.Postgresql.Mappings
{
    public class UserFollowerMapping : IEntityTypeConfiguration<UserFollower>
	{
		public void Configure(EntityTypeBuilder<UserFollower> builder)
		{
			builder.ToTable("UserFollowers");
			builder.HasKey(x => new { x.FollowerId, x.FollowedId });

			builder.HasOne(x => x.Followed)
				   .WithMany(x => x.Followers)
				   .HasForeignKey(x => x.FollowedId)
				   .OnDelete(DeleteBehavior.Restrict);
		}
	}
}
