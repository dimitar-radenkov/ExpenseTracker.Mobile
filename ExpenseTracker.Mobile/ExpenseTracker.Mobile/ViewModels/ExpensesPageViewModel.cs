using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ExpenseTracker.Mobile.Models;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.ViewModels.Helpers;
using ExpenseTracker.Mobile.Views;
using Microsoft.EntityFrameworkCore;
using Prism.Events;
using Prism.Mvvm;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class ExpensesPageViewModel : BindableBase
    {
        private readonly IPageService pageService;
        private readonly IDbService dbService;
        private readonly IEventAggregator eventAggregator;

        public CollectionUI<Expense> ExpensesList { get; private set; }
        public ICommand AddButtonCommand { get; private set; }

        public ExpensesPageViewModel(
            IPageService pageService,
            IDbService dbService,
            IEventAggregator eventAggregator)
        {
            this.pageService = pageService;
            this.dbService = dbService;
            this.eventAggregator = eventAggregator;

            this.Initialize();
        }

        private async Task OnButtonAddClicked()
        {
            await this.pageService.PushAsync(new AddExpensePage());
        }

        private void Initialize()
        {
            var expenses = this.dbService.GetContext().Expenses
                .AsNoTracking()
                .ToList();

            this.ExpensesList = new CollectionUI<Expense>(expenses);
            this.AddButtonCommand = new Command(async() => await OnButtonAddClicked());
        }
    }
}
