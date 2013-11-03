using DansBlog.Utilities.Interfaces;
using System.Xml.Linq;

namespace DansBlog.Utilities.Xml
{
    public class XDocumentLoader : IXDocumentLoader
    {
        public XDocument LoadXDocument(string filePath)
        {
            XDocument xDocument = XDocument.Load(filePath);

            return xDocument;
        }
    }
}
