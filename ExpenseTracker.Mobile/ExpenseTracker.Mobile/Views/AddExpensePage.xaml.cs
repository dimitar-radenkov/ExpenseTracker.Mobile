using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTracker.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpensePage : ContentPage
    {
        public AddExpensePage()
        {
            InitializeComponent();
            this.BindingContext = new AddExpensePageViewModel(
                new CategoriesService(), 
                new PageService(),
                new DbService());
        }
    }
}