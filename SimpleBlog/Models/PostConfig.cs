using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleBlog.Models
{
    public class PostConfig
    {
        public PostConfig(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Title).IsUnique();
            builder.Property(p => p.Content).HasMaxLength(1000);
        }
    }
}