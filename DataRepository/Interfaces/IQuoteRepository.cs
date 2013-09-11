namespace DansBlog.Repository.Interfaces
{
    public interface IQuoteRepository<out T>
    {
        T GetRandomQuote(string filePath);
    }
}
