using System;
using System.Collections.Generic;
using System.Linq;
using Model.Domain;
using Model.Entities;

namespace Model
{
    public class Archiver
    {
        public List<Archive> GetArchivedMonths(DateTime dateTime, int monthsNo, List<Post> blogPosts)
        {
            if (monthsNo < 1) monthsNo = 1;
            if (monthsNo > 12) monthsNo = 12;

            List<DateTime> dateTimeMonths = GetPreviousMonthsInStringFormat(dateTime, monthsNo);

            var archiveList = new List<Archive>();

            for(int i = 0; i < dateTimeMonths.Count(); i++)
            {
                var archive = new Archive
                {
                    MonthName = dateTimeMonths[i].ToLongDateString().Split(' ').ElementAt(1),
                    MonthNumber = dateTimeMonths[i].Month,
                    YearName = dateTimeMonths[i].Year.ToString(),
                    YearNumber = dateTimeMonths[i].Year,
                };

                archiveList.Add(archive);
            }

            List<Archive> v = Foo(archiveList, blogPosts);

            return v;
        }

        private List<DateTime> GetPreviousMonthsInStringFormat(DateTime dateTime, int monthsNo)
        {
            List<DateTime> dateTimeMonths = Enumerable.Range(1, monthsNo)
                                                      .Take(monthsNo)
                                                      .Select(s => dateTime.AddMonths(0 - s))
                                                      .ToList();
            return dateTimeMonths;
        }

        public List<Archive> Foo(List<Archive> UpdateArchivePostCounts, List<Post> blogPosts)
        {
            foreach(var archive in UpdateArchivePostCounts)
            {
                archive.PostCount = blogPosts.Count(p => p.PostDate.Month == archive.MonthNumber && p.PostDate.Year == archive.YearNumber);
            }

            return UpdateArchivePostCounts;
        }
    }
}
