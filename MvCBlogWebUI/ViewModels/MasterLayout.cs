using DansBlog.Model.Entities;
using DansBlog.Model.Partials;
using DansBlog.Services.Archiving.ViewModel;
using System.Collections.Generic;

namespace DansBlog.Presentation.ViewModels
{
    public class MasterLayout
    {
        public List<Archive> ArchivedMonths { get; set; }
        
        public List<Category> Categories { get; set; }
        
        public Quote QuoteOfTheDay { get; set; }
    }
}