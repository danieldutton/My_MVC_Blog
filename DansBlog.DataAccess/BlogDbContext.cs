using DansBlog.Model.Entities;
using System.Data.Entity;

namespace DansBlog.DataAccess
{
    public class BlogDbContext : DbContext , IDbContext
    {
        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Tag> Tags { get; set; } 
        
        public BlogDbContext():base("DansMVCBlog")
        {           
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                        .HasMany(j => j.Categories)
                        .WithMany(j => j.Posts)
                        .Map(x => x.ToTable("PostCategory"));

            modelBuilder.Entity<Post>()
                        .HasMany(j => j.Tags)
                        .WithMany(j => j.Posts)
                        .Map(x => x.ToTable("PostTag"));
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
