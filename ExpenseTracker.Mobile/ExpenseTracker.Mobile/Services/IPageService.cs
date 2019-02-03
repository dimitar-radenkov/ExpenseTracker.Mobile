using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpesneTracker.Mobile.Services
{
    public interface IPageService
    {
        Task PushAsync(Page page);

        Task PopAsync();
    }
}
