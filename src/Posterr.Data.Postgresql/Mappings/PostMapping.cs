using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Posterr.Domain;

namespace Posterr.Repository.Postgresql.Mappings
{
    public class PostMapping : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.ToTable("Posts");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				   .ValueGeneratedOnAdd();

			builder.Property(x => x.Content)
				   .HasMaxLength(777)
				   .IsRequired();

			builder.Property(x => x.RepostedPostId)
				   .ValueGeneratedNever();

			builder.HasOne(x => x.Owner)
				   .WithMany(x => x.Posts)
				   .HasForeignKey(x => x.UserId)
				   .OnDelete(DeleteBehavior.NoAction);
			
			builder.HasOne(x => x.RepostedPost);
			builder.Ignore(x => x.IsOriginal);
			builder.Ignore(x => x.IsQuote);
			builder.Ignore(x => x.IsRepost);
		}
	}
}
