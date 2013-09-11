using System;
using System.Collections.Generic;

namespace DansBlog.Services.Archiving.Interfaces
{
    public interface IDistinctMonthHelper
    {
        List<DateTime> GetDistinctPreviousMonths(DateTime date, int monthsRequired);
    }
}
