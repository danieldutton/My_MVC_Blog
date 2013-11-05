using DansBlog.Services.Archiving.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DansBlog.Utilities.Interfaces;

namespace DansBlog.Services.Archiving.Utilities
{
    public class DistinctMonthHelper : IDistinctMonthHelper
    {
        private readonly ICurrentTime _currentTime;


        public DistinctMonthHelper(ICurrentTime currentTime)
        {
            _currentTime = currentTime;
        }

        public List<DateTime> GetDistinctPreviousMonths(DateTime date, int monthsRequired)
        {
            if (monthsRequired < 1) monthsRequired = 1;

            if (date > _currentTime.GetCurrentTime()) date = _currentTime.GetCurrentTime();

            List<DateTime> months = Enumerable.Range(1, monthsRequired)
                                                      .Take(monthsRequired)
                                                      .Select(s => date.AddMonths(0 - s))
                                                      .ToList();
            return months;
        }
    }
}
