using DansBlog.Utilities.Interfaces;
using System.Xml.Linq;

namespace DansBlog.Utilities.Xml
{
    public class XmlLoader : IXmlLoader
    {
        public XDocument LoadXml(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);

            return doc;
        }
    }
}
