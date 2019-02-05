namespace ExpenseTracker.Mobile.ViewModels.Helpers
{
    public class BaseUI : BaseViewModel
    {
        private bool isEnabled;

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }

        public BaseUI()
        {
            this.IsEnabled = true;
        }
    }
}
