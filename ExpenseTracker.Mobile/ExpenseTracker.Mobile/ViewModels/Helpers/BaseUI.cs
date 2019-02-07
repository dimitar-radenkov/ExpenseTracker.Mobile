using Prism.Mvvm;

namespace ExpenseTracker.Mobile.ViewModels.Helpers
{
    public class BaseUI : BindableBase
    {
        private bool isEnabled;

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetProperty(ref this.isEnabled, value); }
        }

        public BaseUI()
        {
            this.IsEnabled = true;
        }
    }
}
