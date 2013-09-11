using DansBlog.Model.Entities;
using DansBlog.Services.Archiving.Interfaces;
using DansBlog.Services.Archiving.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DansBlog.Services.Archiving.Utilities
{
    public class ArchiveMapper : IArchiveMapper
    {
        public List<Archive> MapArchiveModel(List<DateTime> archives, List<Post> blogPosts)
        {
            if (archives == null || blogPosts == null) throw new ArgumentNullException();

            var archiveList = new List<Archive>();

            for (int i = 0; i < archives.Count(); i++)
            {
                var archive = new Archive
                {
                    MonthName = archives[i].ToLongDateString().Split(' ').ElementAt(1),
                    MonthNumber = archives[i].Month,
                    YearName = archives[i].Year.ToString(),
                    YearNumber = archives[i].Year,
                };
                archive.PostCount = blogPosts.Count(p => p.PublishDate.Month == archive.MonthNumber && p.PublishDate.Year == archive.YearNumber);
                archiveList.Add(archive);
            }
            return archiveList;
        }
    }
}
