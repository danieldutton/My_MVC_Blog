using DansBlog.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DansBlog.Repository.Interfaces
{
    public interface IPostRepository : IEntityRepository<Post>
    {
        List<Post> GetPostsByCategory(string category);

        IEnumerable<IGrouping<int, Post>> PostsGroupedByYear();

        List<Post> GetPostsByDate(int month, int year);

        List<Post> Find(string content);

        List<Comment> GetModeratedPostComments(int postId);

        List<Comment> GetUnModeratedPostComments(int postId);

        //remove postId param and use comment FK
        void AddCommentToPost(Comment comment, int postId);

        void AddModeratedCommentToPost(Comment comment, int postId);
    }
}
