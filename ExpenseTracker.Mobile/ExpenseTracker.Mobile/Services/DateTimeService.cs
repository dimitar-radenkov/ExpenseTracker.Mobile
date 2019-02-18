using System;

namespace ExpenseTracker.Mobile.Services
{

    public class DateTimeService : IDateTimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}