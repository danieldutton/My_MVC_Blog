using DansBlog.Utilities.Interfaces;
using System;

namespace DansBlog.Utilities.DateTimes
{
    public class CurrentTimeHelper : ICurrentDateTime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
