using ExpenseTracker.Mobile.Storage;

namespace ExpenseTracker.Mobile.Services
{
    public interface IDbService
    {
        ExpenseTrackerDbContext GetContext();
    }
}
