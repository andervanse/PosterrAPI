using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posterr.Domain;

namespace Posterr.Repository.Postgresql.Mappings
{
    public class UserSummaryMapping : IEntityTypeConfiguration<UserSummary>
	{
		public void Configure(EntityTypeBuilder<UserSummary> builder)
		{
			builder.ToTable("UserSummaries");
			builder.HasKey(x => x.UserId);
			builder.Property(x => x.UpdatedAt).IsRequired();
			builder.Property(x => x.NumberOfFollowers).IsRequired();
			builder.Property(x => x.NumberOfFollowingUsers).IsRequired();
			builder.Property(x => x.NumberOfPosts).IsRequired();
		}
	}
}
