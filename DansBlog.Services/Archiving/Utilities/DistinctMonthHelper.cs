using DansBlog.Services.Archiving.Interfaces;
using DansBlog.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DansBlog.Services.Archiving.Utilities
{
    public class DistinctMonthHelper : IDistinctMonthHelper
    {
        private readonly ICurrentDateTime _currentDateTime;


        public DistinctMonthHelper(ICurrentDateTime currentDateTime)
        {
            _currentDateTime = currentDateTime;
        }

        public List<DateTime> GetDistinctPreviousMonths(DateTime date, int monthsRequired)
        {
            if (monthsRequired < 1) monthsRequired = 1;

            if (date > _currentDateTime.GetCurrentTime()) date = _currentDateTime.GetCurrentTime();

            List<DateTime> months = Enumerable.Range(1, monthsRequired)
                                                      .Take(monthsRequired)
                                                      .Select(s => date.AddMonths(0 - s))
                                                      .ToList();
            return months;
        }
    }
}
