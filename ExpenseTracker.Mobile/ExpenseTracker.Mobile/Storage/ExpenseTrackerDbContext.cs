using ExpenseTracker.Mobile.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.Storage
{
    public class ExpenseTrackerDbContext : DbContext
    {
        private readonly string filename;

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ExpenseTrackerDbContext(string filename)
        {
            this.filename = filename;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbpathService = DependencyService.Get<IDbPath>();
            optionsBuilder.UseSqlite($"Filename={ dbpathService.GetPath(this.filename) }");
        }
    }
}
