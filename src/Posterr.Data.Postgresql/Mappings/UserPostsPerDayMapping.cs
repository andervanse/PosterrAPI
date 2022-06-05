using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posterr.Domain;

namespace Posterr.Repository.Postgresql.Mappings
{
    public class UserPostsPerDayMapping : IEntityTypeConfiguration<UserPostsPerDay>
	{
		public void Configure(EntityTypeBuilder<UserPostsPerDay> builder)
		{
			builder.ToTable("UserPostsPerDay");
			builder.HasKey(x => x.UserId);
			builder.Property(x => x.Quantity).IsRequired();
			builder.Property(x => x.UpdatedAt).IsRequired();
		}
	}
	
}
