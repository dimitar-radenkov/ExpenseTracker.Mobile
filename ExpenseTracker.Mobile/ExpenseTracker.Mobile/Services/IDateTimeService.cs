using System;

namespace ExpenseTracker.Mobile.Services
{
    public interface IDateTimeService
    {
        DateTime UtcNow { get; }
    }
}
