using DansBlog.Model.Entities;
using System.Data.Entity;

namespace DansBlog.DataAccess
{
    public class BlogDbContext : DbContext 
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; } 
        
        public BlogDbContext():base("DansMVCBlog")
        {           
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                        .HasMany(j => j.Categories)
                        .WithRequired();

            modelBuilder.Entity<Post>()
                        .HasMany(j => j.Comments)
                        .WithRequired();

            modelBuilder.Entity<Post>()
                        .HasMany(j => j.Tags)
                        .WithRequired();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
