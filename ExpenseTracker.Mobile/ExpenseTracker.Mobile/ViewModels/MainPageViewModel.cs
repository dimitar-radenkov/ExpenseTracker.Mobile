using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ExpenseTracker.Mobile.Models;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.View;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IPageService pageService;

        public ObservableCollection<Expense> ExpensesList { get; private set; }
        public ICommand AddButtonCommand { get; private set; }

        public MainPageViewModel(IPageService pageService)
        {
            this.pageService = pageService;

            this.Initialize();
        }

        private async Task OnButtonAddClicked()
        {
            await this.pageService.PushAsync(new AddExpensePage());
        }

        private void Initialize()
        {
            this.ExpensesList = new ObservableCollection<Expense>();
            this.AddButtonCommand = new Command(async() => await OnButtonAddClicked());
        }
    }
}
