using DansBlog.DataAccess;
using DansBlog.Model.Entities;
using DansBlog.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DansBlog.Repository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dataContext;

        public CategoryRepository(IDbContext blogDataContextContext)
        {
            _dataContext = blogDataContextContext;
        }

        public List<Category> All { get { return _dataContext.Categories.ToList(); } }

        public Category Find(int id)
        { 
            return _dataContext.Categories.SingleOrDefault(p => p.CategoryId == id);    
        }

        public void Add(Category entity)
        {
            _dataContext.Categories.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Category entity)
        {
            var posts = _dataContext.Posts.Find(entity);
            _dataContext.Entry(posts).State = EntityState.Modified;
            
            _dataContext.SaveChanges();
        }

        public void Delete(Category entity)
        {
            Post post = _dataContext.Posts.Find(entity);
            _dataContext.Posts.Remove(post);

            _dataContext.SaveChanges();
        }

        public List<Category> MostPopularCategories(int count)
        {
            List<Post> posts = _dataContext.Posts.ToList();

            List<Category> categories = All
                                        .Distinct()
                                        .Take(count)
                                        .OrderByDescending(c => c.Count)
                                        .ToList();

            foreach(var category in categories)
            {
                category.Count = posts.Count(c => c.Categories.Any(d => d.Name.Equals(category.Name)));
            }

            return categories;
        }

    }
}
