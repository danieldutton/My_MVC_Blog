using System.Data.Entity.Infrastructure;
using DansBlog.Model.Entities;
using System.Data.Entity;

namespace DansBlog.DataAccess
{
    public interface IDbContext
    {
        IDbSet<Post> Posts { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Tag> Tags { get; set; }

        int SaveChanges();

        DbEntityEntry Entry(object entity);

    }
}
