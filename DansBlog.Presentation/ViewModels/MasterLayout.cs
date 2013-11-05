using DansBlog.Model.Entities;
using DansBlog.Model.Partials;
using System.Collections.Generic;
using DansBlog.Services.Archiving.ViewModel;

namespace DansBlog.Presentation.ViewModels
{
    public class MasterLayout
    {
        public List<Archive> ArchivedMonths { get; set; }
        
        public List<Category> Categories { get; set; }
        
        public Quote QuoteOfTheDay { get; set; }
    }
}