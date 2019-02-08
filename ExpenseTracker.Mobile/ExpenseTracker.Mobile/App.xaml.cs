using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ExpenseTracker.Mobile
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platfromInitializer = null)
            :base(platfromInitializer)
        { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(nameof(ExpensesPage));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDbService, DbService>();
            containerRegistry.Register<ICategoriesService, CategoriesService>();

            containerRegistry.RegisterForNavigation<ExpensesPage>();
            containerRegistry.RegisterForNavigation<AddExpensePage>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
