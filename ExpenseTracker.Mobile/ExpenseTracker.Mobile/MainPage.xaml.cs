using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.ViewModels;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.BindingContext = new MainPageViewModel(new PageService());
        }
    }
}
