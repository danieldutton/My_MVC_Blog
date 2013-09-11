using DansBlog.Model.Entities;
using System.Collections.Generic;

namespace DansBlog.Repository.Interfaces
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
        List<Category> MostPopularCategories(int count);
    }
}
