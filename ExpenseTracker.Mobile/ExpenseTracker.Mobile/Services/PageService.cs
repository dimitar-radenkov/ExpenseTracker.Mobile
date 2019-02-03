using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.Services
{
    public class PageService : IPageService
    {
        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PopAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}