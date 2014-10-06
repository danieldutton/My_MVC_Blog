using DansBlog.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DansBlog.UnitTests
{
    public static class Mother
    {
        public static List<Post> GetTenPosts_No_Categories_NoComments_No_Tags()
        {
            var posts = new List<Post>
                {
                    new Post{ Id = 1, Title = "Title 1", Content = "Content 1"},
                    new Post{ Id = 2, Title = "Title 2", Content = "Content 2"},
                    new Post{ Id = 3, Title = "Title 3", Content = "Content 3"},
                    new Post{ Id = 4, Title = "Title 4", Content = "Content 4"},
                    new Post{ Id = 5, Title = "Title 5", Content = "Content 5"},
                    new Post{ Id = 6, Title = "Title 6", Content = "Content 6"},
                    new Post{ Id = 7, Title = "Title 7", Content = "Content 7"},
                    new Post{ Id = 8, Title = "Title 8", Content = "Content 8"},
                    new Post{ Id = 9, Title = "Title 9", Content = "Content 9"},
                    new Post{ Id = 10, Title = "Title 10", Content = "Content 10"},
                };
            return posts;
        }


        public static List<Post> GetTenPosts_With_1_Comment_PerPost()
        {
            var posts = new List<Post>
                {
                    new Post{ Id = 1, Title = "Title 1", Content = "Content 1", Comments = new List<Comment>{new Comment{PostId = 1, Content = "Post 1 - Comment 1"}}},
                    new Post{ Id = 2, Title = "Title 2", Content = "Content 2", Comments = new List<Comment>{new Comment{PostId = 2, Content = "Post 2 - Comment 1"}}},
                    new Post{ Id = 3, Title = "Title 3", Content = "Content 3", Comments = new List<Comment>{new Comment{PostId = 3, Content = "Post 3 - Comment 1"}}},
                    new Post{ Id = 4, Title = "Title 4", Content = "Content 4", Comments = new List<Comment>{new Comment{PostId = 4, Content = "Post 4 - Comment 1"}}},
                    new Post{ Id = 5, Title = "Title 5", Content = "Content 5", Comments = new List<Comment>{new Comment{PostId = 5, Content = "Post 5 - Comment 1"}}},
                    new Post{ Id = 6, Title = "Title 6", Content = "Content 6", Comments = new List<Comment>{new Comment{PostId = 6, Content = "Post 6 - Comment 1"}}},
                    new Post{ Id = 7, Title = "Title 7", Content = "Content 7", Comments = new List<Comment>{new Comment{PostId = 7, Content = "Post 7 - Comment 1"}}},
                    new Post{ Id = 8, Title = "Title 8", Content = "Content 8", Comments = new List<Comment>{new Comment{PostId = 8, Content = "Post 8 - Comment 1"}}},
                    new Post{ Id = 9, Title = "Title 9", Content = "Content 9", Comments = new List<Comment>{new Comment{PostId = 9, Content = "Post 9 - Comment 1"}}},
                    new Post{ Id = 10, Title = "Title 10", Content = "Content 10", Comments = new List<Comment>{new Comment{PostId = 10, Content = "Post 10 - Comment 1"}}},
                };
            return posts;
        }

        public static List<Tag> GetDistinctTags()
        {
            var tags = new List<Tag>
                {
                    new Tag {TagId = 1, Name = "Tag 1"},
                    new Tag {TagId = 2, Name = "Tag 2"},
                    new Tag {TagId = 3, Name = "Tag 3"},
                    new Tag {TagId = 4, Name = "Tag 4"},
                    new Tag {TagId = 5, Name = "Tag 5"},
                    new Tag {TagId = 6, Name = "Tag 6"},
                    new Tag {TagId = 7, Name = "Tag 7"},
                    new Tag {TagId = 8, Name = "Tag 8"},
                    new Tag {TagId = 9, Name = "Tag 9"},
                    new Tag {TagId = 10, Name = "Tag 10"},
                };

            return tags;
        }

        public static List<Comment> GetTenComments_With_5_Moderated()
        {
            var comments = new List<Comment>
                {
                    new Comment{CreationTime = new DateTime(2013, 10, 1), Author = "Daniel Dutton", Email = "dan@dan.com", HasBeenModerated = true, Content = "New Content 1"},
                    new Comment{CreationTime = new DateTime(2013, 10, 1), Author = "Daniel Dutton", Email = "dan@dan.com", HasBeenModerated = true, Content = "New Content 2"},
                    new Comment{CreationTime = new DateTime(2013, 10, 1), Author = "Daniel Dutton", Email = "dan@dan.com", HasBeenModerated = true, Content = "New Content 3"},
                    new Comment{CreationTime = new DateTime(2013, 10, 1), Author = "Daniel Dutton", Email = "dan@dan.com", HasBeenModerated = true, Content = "New Content 4"},
                    new Comment{CreationTime = new DateTime(2013, 10, 1), Author = "Daniel Dutton", Email = "dan@dan.com", HasBeenModerated = true, Content = "New Content 5"},
                    new Comment{CreationTime = new DateTime(2013, 10, 1), Author = "Daniel Dutton", Email = "dan@dan.com", HasBeenModerated = false, Content = "New Content 6"},
                    new Comment{CreationTime = new DateTime(2013, 10, 1), Author = "Daniel Dutton", Email = "dan@dan.com", HasBeenModerated = false, Content = "New Content 7"},
                    new Comment{CreationTime = new DateTime(2013, 10, 1), Author = "Daniel Dutton", Email = "dan@dan.com", HasBeenModerated = false, Content = "New Content 8"},
                    new Comment{CreationTime = new DateTime(2013, 10, 1), Author = "Daniel Dutton", Email = "dan@dan.com", HasBeenModerated = false, Content = "New Content 9"},
                    new Comment{CreationTime = new DateTime(2013, 10, 1), Author = "Daniel Dutton", Email = "dan@dan.com", HasBeenModerated = false, Content = "New Content 10"},
                };

            return comments;
        }

        public static XDocument GetXDocument()
        {
            var srcTree = new XDocument(
                new XComment("This is a comment"),
                new XElement("quotes",
                             new XElement("quote", new XAttribute("id", "1"), new XElement("text", "text1"),
                                          new XElement("author", "author1")),
                             new XElement("quote", new XAttribute("id", "2"), new XElement("text", "text2"),
                                          new XElement("author", "author2")),
                             new XElement("quote", new XAttribute("id", "3"), new XElement("text", "text3"),
                                          new XElement("author", "author3")),
                             new XElement("quote", new XAttribute("id", "4"), new XElement("text", "text4"),
                                          new XElement("author", "author4")),
                             new XElement("quote", new XAttribute("id", "5"), new XElement("text", "text5"),
                                          new XElement("author", "author5")),
                             new XElement("quote", new XAttribute("id", "6"), new XElement("text", "text6"),
                                          new XElement("author", "author6")),
                             new XElement("quote", new XAttribute("id", "7"), new XElement("text", "text7"),
                                          new XElement("author", "author7")),
                             new XElement("quote", new XAttribute("id", "8"), new XElement("text", "text8"),
                                          new XElement("author", "author8")),
                             new XElement("quote", new XAttribute("id", "9"), new XElement("text", "text9"),
                                          new XElement("author", "author9")),
                             new XElement("quote", new XAttribute("id", "10"), new XElement("text", "text10"),
                                          new XElement("author", "author10"))
                    )
                );
            return srcTree;
        }

        public static List<Post> GetTenPostsInRandomOrder()
        {
            var posts = new List<Post>
                {
                    new Post {Id = 1}, new Post {Id = 7}, new Post {Id = 10},
                    new Post {Id = 6}, new Post {Id = 4}, new Post {Id = 3}, 
                    new Post {Id = 2}, new Post {Id = 8}, new Post {Id = 5}, 
                    new Post {Id = 9},
                };

            return posts;
        }

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
