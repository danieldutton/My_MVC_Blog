using DansBlog.Model.Entities;
using DansBlog.Services.Archiving.ViewModel;
using System;
using System.Collections.Generic;

namespace DansBlog.Services.Archiving.Interfaces
{
    public interface IArchiver
    {
        List<Archive> GetArchivedMonths(DateTime currentDate, int pastMonthsRequired, List<Post> blogPosts);
    }
}
