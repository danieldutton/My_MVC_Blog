using DansBlog.Utilities.Interfaces;
using System;

namespace DansBlog.Utilities.DateTimes
{
    public class CurrentTimeHelper : ICurrentTime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
