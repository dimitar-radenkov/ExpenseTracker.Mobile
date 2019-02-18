using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
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
        private readonly IDateTimeService dateTimeService;
        private readonly ICategoriesService categoriesService;
        private readonly INavigationService navigationService;
        private readonly IEventAggregator eventAggregator;

        public CollectionUI<WeekControlViewModel> Weeks { get; private set; }
        public CollectionUI<Expense> ExpensesList { get; private set; }
        public ICommand AddButtonCommand { get; private set; }

        public InitialPageViewModel(
            ExpenseTrackerDbContext db,
            IDateTimeService dateTimeService,
            ICategoriesService categoriesService,
            INavigationService navigationService,
            IEventAggregator eventAggregator)
        {
            this.db = db;
            this.dateTimeService = dateTimeService;
            this.categoriesService = categoriesService;
            this.navigationService = navigationService;
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
                .Subscribe(async () => await this.RefreshAsync() );

            this.ExpensesList = new CollectionUI<Expense>();
            this.AddButtonCommand = new Command(async() => await OnButtonAddClicked());

            this.RefreshAsync().ConfigureAwait(false);
        }

        private async Task RefreshAsync()
        {
            var expenses = await this.db.Expenses.AsNoTracking()
                .ToListAsync();

            expenses.ForEach(x => x.ImageUrl = this.categoriesService.GetUrl(x.CategoryId));

            this.ExpensesList.Items.Clear();
            this.ExpensesList.Items.AddRange(expenses);
        }
    }
}
