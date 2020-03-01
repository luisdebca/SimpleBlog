using Microsoft.EntityFrameworkCore;

namespace SimpleBlog.Models
{
    public class BlogContext: DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=tcp:127.0.0.1,1433;Database=BlogDB;User ID=SA;Password=Sqlserver2017;Encrypt=false;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var postConfig = new PostConfig(modelBuilder.Entity<Post>());
        }
    }
}