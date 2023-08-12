using learn_specification.Entities;
using Microsoft.EntityFrameworkCore;

namespace learn_specification.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }
        // Specify default value for DateTime columns
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Post>()
                .Property(b => b.LastModifiedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Post>()
                .Property(b => b.PublishedOn)
                .HasDefaultValueSql("getdate()");

            // Repeat above lines
            // For tags, categories and comments
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategories> PostCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}