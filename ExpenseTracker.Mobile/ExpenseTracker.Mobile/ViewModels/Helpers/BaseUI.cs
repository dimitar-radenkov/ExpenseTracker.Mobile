using Prism.Mvvm;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels.Helpers
{
    public class BaseUI : BindableBase
    {
        private bool isEnabled;
        private Color background;

        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetProperty(ref this.isEnabled, value);
        }

        public Color Background
        {
            get => this.background;
            set => this.SetProperty(ref this.background, value);
        }

        public BaseUI()
        {           
            this.IsEnabled = true;
        }
    }
}
