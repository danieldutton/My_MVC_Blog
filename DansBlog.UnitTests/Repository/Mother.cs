using System.Collections.Generic;
using System.Xml.Linq;
using DansBlog.Model.Entities;

namespace DansBlog.UnitTests.Repository
{
    public static class Mother
    {
        public static XDocument GetXDocument()
        {
            var srcTree = new XDocument(
                new XComment("This is a comment"),
                new XElement("quotes",
                             new XElement("quote", new XAttribute("id", "1"), new XElement("text", "text1"),
                                          new XElement("author", "author1")),
                             new XElement("quote", new XAttribute("id", "2"), new XElement("text", "text2"),
                                          new XElement("author", "author2")),
                             new XElement("quote", new XAttribute("id", "3"), new XElement("text", "text3"),
                                          new XElement("author", "author3")),
                             new XElement("quote", new XAttribute("id", "4"), new XElement("text", "text4"),
                                          new XElement("author", "author4")),
                             new XElement("quote", new XAttribute("id", "5"), new XElement("text", "text5"),
                                          new XElement("author", "author5")),
                             new XElement("quote", new XAttribute("id", "6"), new XElement("text", "text6"),
                                          new XElement("author", "author6")),
                             new XElement("quote", new XAttribute("id", "7"), new XElement("text", "text7"),
                                          new XElement("author", "author7")),
                             new XElement("quote", new XAttribute("id", "8"), new XElement("text", "text8"),
                                          new XElement("author", "author8")),
                             new XElement("quote", new XAttribute("id", "9"), new XElement("text", "text9"),
                                          new XElement("author", "author9")),
                             new XElement("quote", new XAttribute("id", "10"), new XElement("text", "text10"),
                                          new XElement("author", "author10"))
                    )
                );
            return srcTree;
        }

        public static List<Post> GetTenPostsInRandomOrder()
        {
            var posts = new List<Post>
                {
                    new Post {Id = 1}, new Post {Id = 7}, new Post {Id = 10},new Post {Id = 6}, new Post {Id = 4},
                    new Post {Id = 3}, new Post {Id = 2}, new Post {Id = 8}, new Post {Id = 5}, new Post {Id = 9},
                };

            return posts;
        } 
    }
}
