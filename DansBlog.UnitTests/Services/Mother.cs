using DansBlog.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DansBlog._UnitTests.Services
{
    public static class Mother
    {
        public static List<Post> GetFiveSimpleBlogPosts()
        {
            var posts = new List<Post>
                {
                    new Post{Id = 1, Title = "Title 1", Content = "Content 1", PublishDate = new DateTime(2013, 8, 4)},
                    new Post{Id = 2, Title = "Title 2", Content = "Content 2", PublishDate = new DateTime(2013, 8, 4)},
                    new Post{Id = 3, Title = "Title 3", Content = "Content 3", PublishDate = new DateTime(2013, 8, 4)},
                    new Post{Id = 4, Title = "Title 4", Content = "Content 4", PublishDate = new DateTime(2013, 8, 4)},
                    new Post{Id = 5, Title = "Title 5", Content = "Content 5", PublishDate = new DateTime(2013, 8, 4)},
                    new Post{Id = 6, Title = "Title 6", Content = "Content 6", PublishDate = new DateTime(2013, 8, 4)},
                    new Post{Id = 7, Title = "Title 7", Content = "Content 7", PublishDate = new DateTime(2013, 8, 4)},
                    new Post{Id = 8, Title = "Title 8", Content = "Content 8", PublishDate = new DateTime(2013, 8, 4)},
                    new Post{Id = 9, Title = "Title 9", Content = "Content 9", PublishDate = new DateTime(2013, 8, 4)},
                    new Post{Id = 10, Title = "Title 10", Content = "Content 10", PublishDate = new DateTime(2013, 8, 4)},
                };
            return posts;
        }

        public static List<DateTime> GetListOfFiveDateTimes()
        {
            var dateTimes = new List<DateTime>
                {
                    new DateTime(2013, 08, 04),
                    new DateTime(2013, 08, 04),
                    new DateTime(2013, 08, 04),
                    new DateTime(2013, 08, 04),
                    new DateTime(2013, 08, 04),
                };
            return dateTimes;
        }

        public static List<Post> GetTwentyMixedDateAndYearPosts()
        {
            var posts = new List<Post>
                {
                    new Post{Id = 1, Title = "Post 1 Title", Content = "Post 1 Content", PublishDate = new DateTime(2013, 8, 8)},
                    new Post{Id = 2, Title = "Post 2 Title", Content = "Post 2 Content", PublishDate = new DateTime(2013, 8, 8)},
                    new Post{Id = 3, Title = "Post 3 Title", Content = "Post 3 Content", PublishDate = new DateTime(2013, 7, 8)},
                    new Post{Id = 4, Title = "Post 4 Title", Content = "Post 4 Content", PublishDate = new DateTime(2013, 6, 8)},
                    new Post{Id = 5, Title = "Post 5 Title", Content = "Post 5 Content", PublishDate = new DateTime(2013, 5, 8)},
                    new Post{Id = 6, Title = "Post 6 Title", Content = "Post 6 Content", PublishDate = new DateTime(2013, 2, 8)},
                    new Post{Id = 7, Title = "Post 7 Title", Content = "Post 7 Content", PublishDate = new DateTime(2013, 2, 8)},
                    new Post{Id = 8, Title = "Post 8 Title", Content = "Post 8 Content", PublishDate = new DateTime(2013, 8, 8)},
                    new Post{Id = 9, Title = "Post 9 Title", Content = "Post 9 Content", PublishDate = new DateTime(2013, 4, 8)},
                    new Post{Id = 10, Title = "Post 10 Title", Content = "Post 10 Content", PublishDate = new DateTime(2013, 1, 8)},
                    new Post{Id = 11, Title = "Post 11 Title", Content = "Post 11 Content", PublishDate = new DateTime(2012, 8, 8)},
                    new Post{Id = 12, Title = "Post 12 Title", Content = "Post 12 Content", PublishDate = new DateTime(2012, 8, 8)},
                    new Post{Id = 13, Title = "Post 13 Title", Content = "Post 13 Content", PublishDate = new DateTime(2012, 7, 8)},
                    new Post{Id = 14, Title = "Post 14 Title", Content = "Post 14 Content", PublishDate = new DateTime(2012, 6, 8)},
                    new Post{Id = 15, Title = "Post 15 Title", Content = "Post 15 Content", PublishDate = new DateTime(2011, 5, 8)},
                    new Post{Id = 16, Title = "Post 16 Title", Content = "Post 16 Content", PublishDate = new DateTime(2011, 2, 8)},
                    new Post{Id = 17, Title = "Post 17 Title", Content = "Post 17 Content", PublishDate = new DateTime(2011, 2, 8)},
                    new Post{Id = 18, Title = "Post 18 Title", Content = "Post 18 Content", PublishDate = new DateTime(2011, 8, 8)},
                    new Post{Id = 19, Title = "Post 19 Title", Content = "Post 19 Content", PublishDate = new DateTime(2013, 4, 8)},
                    new Post{Id = 20, Title = "Post 20 Title", Content = "Post 20 Content", PublishDate = new DateTime(2013, 1, 8)},
                };

            return posts;
        }

        public static IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
