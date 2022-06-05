using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posterr.Domain;

namespace Posterr.Repository.Postgresql.Mappings
{
	public class UserMapping : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("Users");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				   .ValueGeneratedOnAdd();

			builder.Property(x => x.Name)
				   .HasMaxLength(14)
				   .IsRequired();

			builder.Property(x => x.CreatedAt)
				   .IsRequired();

			builder.HasOne(x => x.Summary)
				   .WithOne()
				   .HasForeignKey<UserSummary>(x => x.UserId)
				   .OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.TodayPosts)
				   .WithOne()
				   .HasForeignKey<UserPostsPerDay>(x => x.UserId)
				   .OnDelete(DeleteBehavior.Restrict);
		}
	}
}
