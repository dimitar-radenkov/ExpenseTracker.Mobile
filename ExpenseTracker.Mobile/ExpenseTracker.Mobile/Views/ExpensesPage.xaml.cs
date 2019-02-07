using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.ViewModels;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.Views
{
    public partial class ExpensesPage : ContentPage
    {
        public ExpensesPage()
        {
            this.InitializeComponent();
            this.BindingContext = new ExpensesPageViewModel(
                new PageService(), 
                new DbService());
        }
    }
}
