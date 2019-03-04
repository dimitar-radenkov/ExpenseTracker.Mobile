using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Mobile.Services;

namespace ExpenseTracker.Mobile.Utils
{
    public class DateTimeUtils
    {
        public static IEnumerable<DateTime> GetCurrentWeek(IDateTimeService dateTimeService)
        {
            var now = dateTimeService.UtcNow;
            var currentDay = now.DayOfWeek;
            int days = (int)currentDay;
            DateTime sunday = now.AddDays(-days);

            return Enumerable.Range(1, 7)
                .Select(d => sunday.AddDays(d))
                .ToList();
        }
    }
}
