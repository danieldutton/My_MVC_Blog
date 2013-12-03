using System.Data.Entity;

namespace DansBlog.DataAccess
{
    public class BlogDataInitializer : CreateDatabaseIfNotExists<BlogDbContext>
    {
        protected override void Seed(BlogDbContext context)
        {
            //seed data here

            base.Seed(context);
        }
    }
}
