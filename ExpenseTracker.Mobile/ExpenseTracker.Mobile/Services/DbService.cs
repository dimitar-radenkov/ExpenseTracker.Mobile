using ExpenseTracker.Mobile.Storage;

namespace ExpenseTracker.Mobile.Services
{

    public class DbService : IDbService
    {
        public ExpenseTrackerDbContext GetContext()
        {
            var context = new ExpenseTrackerDbContext(Constants.DbFile);
            context.Database.EnsureCreated();

            return context;
        }
    }
}