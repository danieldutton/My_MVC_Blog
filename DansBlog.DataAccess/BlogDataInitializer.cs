using DansBlog.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DansBlog.DataAccess
{
    public class BlogDataInitializer : DropCreateDatabaseAlways<BlogDbContext>
    {
        protected override void Seed(BlogDbContext context)
        {
            //seed data here
            var posts = new List<Post>
                {
                    new Post{PublishDate = new DateTime(2011, 7, 4), Author = "Author 1", Title = "Title 1", Content = "Content 1", Categories = new List<Category>{new Category{Name = "Category One"}}},
                    new Post{PublishDate = new DateTime(2011, 7, 4), Author = "Author 2", Title = "Title 2", Content = "Content 2", Categories = new List<Category>{new Category{Name = "Category Two"}}},
                    new Post{PublishDate = new DateTime(2011, 7, 4), Author = "Author 3", Title = "Title 3", Content = "Content 3", Categories = new List<Category>{new Category{Name = "Category Three"}}},
                    new Post{PublishDate = new DateTime(2011, 7, 4), Author = "Author 4", Title = "Title 4", Content = "Content 4", Categories = new List<Category>{new Category{Name = "Category Four"}}},
                    new Post{PublishDate = new DateTime(2011, 7, 4), Author = "Author 5", Title = "Title 5", Content = "Content 5", Categories = new List<Category>{new Category{Name = "Category Five"}}},
                    new Post{PublishDate = new DateTime(2011, 7, 4), Author = "Author 6", Title = "Title 6", Content = "Content 6", Categories = new List<Category>{new Category{Name = "Category Six"}}},
                    new Post{PublishDate = new DateTime(2011, 7, 4), Author = "Author 7", Title = "Title 7", Content = "Content 7", Categories = new List<Category>{new Category{Name = "Category Seven"}}},
                    new Post{PublishDate = new DateTime(2011, 7, 4), Author = "Author 8", Title = "Title 8", Content = "Content 8", Categories = new List<Category>{new Category{Name = "Category Eight"}}},
                    new Post{PublishDate = new DateTime(2011, 7, 4), Author = "Author 9", Title = "Title 9", Content = "Content 9", Categories = new List<Category>{new Category{Name = "Category Nine"}}},
                    new Post{PublishDate = new DateTime(2011, 7, 4), Author = "Author 10", Title = "Title 10", Content = "Content 10", Categories = new List<Category>{new Category{Name = "Category Ten"}}},
                };

            foreach (var post in posts)
            {
                context.Posts.Add(post);
            }

            base.Seed(context);
        }
    }
}
