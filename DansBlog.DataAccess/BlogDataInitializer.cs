using DansBlog.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DansBlog.DataAccess
{
    public class BlogDataInitializer : CreateDatabaseIfNotExists<BlogDbContext>
    {
        protected override void Seed(BlogDbContext context)
        {
            var postsList = new List<Post>
            {               
            new Post
            {
               Title = "Blog 3 Title Category Random Category",
               PublishDate = new DateTime(2012, 11, 23),
               Content = "Content for Blog 3 woohoo Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nisl dolor, volutpat a vehicula et, scelerisque non purus. Vestibulum at semper purus. Nunc gravida mollis posuere. Mauris vel condimentum diam. Morbi at pulvinar enim. Vivamus et neque sed ipsum tincidunt ultricies nec sit amet eros",
               Author = "Daniel Dutton",
               Comments = new List<Comment>
            {
               new Comment
               {
                  Author = "Daniel Dutton",
                  Content = "Blog 3 Comment 3",
                  Email = "danielbdutton@hotmail.co.uk",
                  CreationTime = DateTime.Now,
                  HasBeenModerated = true,
                }    
             },
              Categories = new List<Category>
                              {
                                  new Category{Name = "Random Category"},
                              }
            },

           };

            foreach (var post in postsList)
            {
                context.Posts.Add(post);
            }

            base.Seed(context);
        }
    }
}
