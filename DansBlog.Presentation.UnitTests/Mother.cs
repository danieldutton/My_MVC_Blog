using DansBlog.Model.Entities;
using DansBlog.Services.Email.Model;
using System.Collections.Generic;
namespace DansBlog.UnitTests.Presentation
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
        
        public static Contact GetContactWithInValidModelState()
        {
            return new Contact {Name = "Daniel Dutton", Email = null, Subject = null, Message = null};
        }

        public static Contact GetContactWithValidModelState()
        {
            return new Contact { Name = "Daniel Dutton", Email = "dan@dan.com", Subject = "Test Subject", Message = "Test Message" };
        }

    }
}
