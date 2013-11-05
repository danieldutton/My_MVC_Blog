using DansBlog.Model.Entities;
using DansBlog.Services.Archiving.ViewModel;
using System;
using System.Collections.Generic;

namespace DansBlog.Services.Archiving.Interfaces
{
    public interface IArchiveMapper
    {
        List<Archive> MapArchiveModel(List<DateTime> archives, List<Post> blogPosts);
    }
}
