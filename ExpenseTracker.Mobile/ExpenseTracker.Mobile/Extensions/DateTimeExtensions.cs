using System;
using System.Globalization;

namespace ExpenseTracker.Mobile.Extensions
{
    public static class DateTimeExtensions
    {
        public static string GetMonth(this DateTime dateTime) => 
            dateTime.ToString("MMM", CultureInfo.InvariantCulture);
    }
}
