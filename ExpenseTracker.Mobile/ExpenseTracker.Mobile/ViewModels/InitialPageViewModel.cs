using System;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTracker.Mobile.Events;
using ExpenseTracker.Mobile.Extensions;
using ExpenseTracker.Mobile.Models;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.Storage;
using ExpenseTracker.Mobile.ViewModels.Helpers;
using ExpenseTracker.Mobile.Views;
using Microsoft.EntityFrameworkCore;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class InitialPageViewModel : BindableBase
    {
        private readonly ExpenseTrackerDbContext db;
        private readonly ICategoriesService categoriesService;
        private readonly INavigationService navigationService;
        private readonly IDateTimeService dateTimeService;
        private readonly IEventAggregator eventAggregator;

        public CollectionUI<Expense> ExpensesList { get; private set; }
        public ButtonUI AddButton { get; private set; }

        public InitialPageViewModel(
            ExpenseTrackerDbContext localDb,
            ICategoriesService categoriesService,
            INavigationService navigationService,
            IDateTimeService dateTimeService,
            IEventAggregator eventAggregator)
        {
            this.db = localDb;
            this.categoriesService = categoriesService;
            this.navigationService = navigationService;
            this.dateTimeService = dateTimeService;
            this.eventAggregator = eventAggregator;

            this.Initialize();
        }

        private async Task OnButtonAddClicked()
        {
            await this.navigationService.NavigateAsync(nameof(AddExpensePage));
        }

        private void Initialize()
        {
            this.eventAggregator
                .GetEvent<ExpenseAddedEvent>()
                .Subscribe(async () => await this.RefreshAsync(this.dateTimeService.UtcNow) );

            this.eventAggregator
                .GetEvent<DateSelectedEvent>()
                .Subscribe(async (date) => await this.RefreshAsync(date));

            this.ExpensesList = new CollectionUI<Expense>();
            this.AddButton = new ButtonUI(new Command(async () => await this.OnButtonAddClicked()));

            this.RefreshAsync(this.dateTimeService.UtcNow);
        }

        private async Task RefreshAsync(DateTime dateTime)
        {
            var expenses = await this.db.Expenses.AsNoTracking()
                .Where(x => x.CreationDate.Date == dateTime.Date)
                .ToListAsync();

            expenses.ForEach(x => x.ImageUrl = this.categoriesService.GetUrl(x.CategoryId));

            this.ExpensesList.Items.Clear();
            this.ExpensesList.Items.AddRange(expenses);
        }
    }
}
