using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ExpesneTracker.Mobile.Services;
using ExpesneTracker.Mobile.View;
using Xamarin.Forms;

namespace ExpesneTracker.Mobile.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IPageService pageService;

        public ObservableCollection<ExpenseViewModel> ExpensesList { get; private set; }
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
            this.ExpensesList = new ObservableCollection<ExpenseViewModel>();
            this.AddButtonCommand = new Command(async() => await OnButtonAddClicked());
        }
    }
}
