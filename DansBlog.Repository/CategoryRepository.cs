using DansBlog.DataAccess.Interfaces;
using DansBlog.Model.Entities;
using DansBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DansBlog.Repository
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
            var category = _dataContext.Categories.
                FirstOrDefault(c => c.Name.Equals(entity.Name, StringComparison.InvariantCultureIgnoreCase));
            
            if (category != null) return;
            
            _dataContext.Categories.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(Category entity)
        {
            var category = _dataContext.Categories.
                FirstOrDefault(c => c.Name.Equals(entity.Name, StringComparison.InvariantCultureIgnoreCase));
            
            if (category != null) return;

            _dataContext.SetModified(entity);
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
                category.Count = posts.Count(c => c.Categories
                    .Any(d => d.Name
                        .Equals(category.Name)));
            }

            return categories;
        }

        public List<string> SearchForCategories(string term)
        {
            List<string> result = _dataContext.Categories.Select(x => x.Name)
                    .Where(x => x.ToLower()
                    .Contains(term.ToLower()))
                    .Distinct()
                    .ToList();

            return result;
        }

    }
}
