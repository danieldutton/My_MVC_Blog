using System.Xml.Linq;

namespace DansBlog.Utilities.Interfaces
{
    public interface IXDocumentLoader
    {
        XDocument LoadXDocument(string filePath);
    }
}
