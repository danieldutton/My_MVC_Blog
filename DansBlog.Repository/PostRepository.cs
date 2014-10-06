using DansBlog.DataAccess;
using DansBlog.DataAccess.Interfaces;
using DansBlog.Model.Entities;
using DansBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DansBlog.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly IDbContext _dataContext;

        public List<Post> All
        {
            get { return _dataContext.Posts.OrderByDescending(p => p.PublishDate).ToList(); }
        }


        public PostRepository(IDbContext dataContext)
        {
            _dataContext = dataContext;
        }       

        public void Add(Post element)
        {
            element.PublishDate = DateTime.Now; //ToDo Abstract with interface
            
            _dataContext.Posts.Add(element);
            _dataContext.SaveChanges();
        }

        public void Update(Post post)
        {
            _dataContext.SetModified(post);
            _dataContext.SaveChanges();
        }
        
        public Post Find(int id)
        {
            return _dataContext.Posts.Find(id);
        }

        public List<Post> Find(string content)
        {
            List<Post> result = All.
                Where(c => c.Content
                    .IndexOf(content, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

            return result;
        }

        public List<Post> GetPostByTag(string tagName)
        {
            List<Post> result = All.
                Where(a => a.Tags.
                    Any(b => b.Name.Contains(tagName)))
                    .ToList();

            return result;
        }

        public List<Comment> GetModeratedPostComments(int postId)
        {
            Post result1 = All.SingleOrDefault(p => p.Id == postId);
            
            if (result1 == null) return null;

            List<Comment> result = All.
                SingleOrDefault(p => p.Id == postId)
                .Comments
                .Where(p => p.HasBeenModerated)
                .OrderBy(c => c.CreationTime)
                .ToList();

            return result;
        }

        public List<Comment> GetUnModeratedPostComments(int postId)
        {
            Post result1 = All.SingleOrDefault(p => p.Id == postId);
            if (result1 == null) return null;
            
            List<Comment> result =  All.
                SingleOrDefault(p => p.Id == postId)
                .Comments
                .Where(p => !p.HasBeenModerated)
                .OrderBy(c => c.CreationTime)
                .ToList();

            return result;
        }

        public void Delete(Post element)
        {
            var post = _dataContext.Posts.SingleOrDefault(p => p.Id == element.Id);
            _dataContext.Posts.Remove(post);

            _dataContext.SaveChanges();
        }

        public List<Post> GetPostsByCategory(string category)
        {
            List<Post> posts = All;
            
            List<Post> postsByCategory = posts.
                Where(a => a.Categories
                    .Any(b => b.Name
                        .Contains(category)))
                        .ToList();

            return postsByCategory;
        }

        public IEnumerable<IGrouping<int, Post>> PostsGroupedByYear()
        {
            IEnumerable<IGrouping<int, Post>> groupedPosts = _dataContext.Posts
                                              .AsEnumerable()
                                              .OrderByDescending(s => s.PublishDate)
                                              .GroupBy(s => s.PublishDate.Year)
                                              .OrderByDescending(p => p.Key)
                                              .ToList();
                         
            return groupedPosts;
        }

        public List<Post> GetPostsByDate(int month, int year)
        {
            return All.Where(p => p.PublishDate.Month == month && p.PublishDate.Year == year)
                            .OrderByDescending(p => p.PublishDate).ToList();
        }

        //violates srp move in due course
        public List<Tag> GetDistinctTags()
        {
            return _dataContext.Tags.ToList()
                .Distinct()
                .ToList();
        }

        public void AddCommentToPost(Comment comment, int postId)
        {
            Post post = _dataContext.Posts.SingleOrDefault(p => p.Id == postId);
            comment.CreationTime = DateTime.Now;
            
            if (post != null)
            {
                post.Comments.Add(comment);
                _dataContext.SetModified(post);
            }
            _dataContext.SaveChanges();            
        }

        public void AddModeratedCommentToPost(Comment comment, int postId)
        {
            Post post = _dataContext.Posts.SingleOrDefault(p => p.Id == postId);
            comment.CreationTime = DateTime.Now;

            if (post != null)
            {
                comment.HasBeenModerated = true;
                post.Comments.Add(comment);
                _dataContext.SetModified(post);
            }
            _dataContext.SaveChanges();
        }
    }
}
