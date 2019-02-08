using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ExpenseTracker.Mobile.Events;
using ExpenseTracker.Mobile.Models;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.ViewModels.Helpers;
using ExpenseTracker.Mobile.Views;
using Microsoft.EntityFrameworkCore;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class ExpensesPageViewModel : BindableBase
    {
        private readonly INavigationService navigationService;
        private readonly IDbService dbService;
        private readonly IEventAggregator eventAggregator;

        public CollectionUI<Expense> ExpensesList { get; private set; }
        public ICommand AddButtonCommand { get; private set; }

        public ExpensesPageViewModel(
            INavigationService navigationService,
            IDbService dbService,
            IEventAggregator eventAggregator)
        {
            this.navigationService = navigationService;
            this.dbService = dbService;
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
                .GetEvent<TestEvent>()
                .Subscribe(x => { int a = 4; });

            var expenses = this.dbService.GetContext().Expenses
                .AsNoTracking()
                .ToList();

            this.ExpensesList = new CollectionUI<Expense>(expenses);
            this.AddButtonCommand = new Command(async() => await OnButtonAddClicked());
        }
    }
}
