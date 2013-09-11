using DansBlog.Model.Partials;
using DansBlog.Repository.Interfaces;

namespace DansBlog.Repository
{
    public class RepositoryBundle
    {
        public IPostRepository PostRepository { get; set; }

        public IQuoteRepository<Quote> QuoteRepository { get; set; }

        public ICategoryRepository CategoryRepository { get; set; }


        public RepositoryBundle(IPostRepository postRepository, IQuoteRepository<Quote> quoteRepository,
            ICategoryRepository categoryRepository)
        {
            PostRepository = postRepository;
            QuoteRepository = quoteRepository;
            CategoryRepository = categoryRepository;
        }
    }
}
