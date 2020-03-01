using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleBlog.Models
{
    public class CommentConfig
    {
        public CommentConfig(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Commentary).IsRequired().HasMaxLength(100);
        }
    }
}