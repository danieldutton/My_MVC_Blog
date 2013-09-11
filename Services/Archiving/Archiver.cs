using DansBlog.Model.Entities;
using DansBlog.Services.Archiving.Interfaces;
using DansBlog.Services.Archiving.ViewModel;
using System;
using System.Collections.Generic;

namespace DansBlog.Services.Archiving
{
    public class Archiver : IArchiver
    {
        private readonly IDistinctMonthHelper _distinctMonthHelper;

        private readonly IArchiveMapper _archiveMapper;


        public Archiver(IDistinctMonthHelper distinctMonthHelper,
                        IArchiveMapper archiveMapper)
        {
            _distinctMonthHelper = distinctMonthHelper;
            _archiveMapper = archiveMapper;
        }


        public List<Archive> GetArchivedMonths(DateTime currentDate, int pastMonthsRequired, List<Post> blogPosts)
        {
            if (blogPosts == null) throw new ArgumentNullException("blogPosts");

            List<DateTime> previousMonths = _distinctMonthHelper.GetDistinctPreviousMonths(currentDate, pastMonthsRequired);

            List<Archive> archivedMonths = _archiveMapper.MapArchiveModel(previousMonths, blogPosts);

            return archivedMonths;
        }
    }
}
