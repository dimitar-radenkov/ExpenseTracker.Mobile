using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.Services
{
    public interface IPageService
    {
        Task PushAsync(Page page);

        Task PopAsync();
    }
}
