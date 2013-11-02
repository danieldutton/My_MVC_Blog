using System.Xml.Linq;

namespace DansBlog.Utilities.Interfaces
{
    public interface IXmlLoader
    {
        XDocument LoadXml(string filePath);
    }
}
