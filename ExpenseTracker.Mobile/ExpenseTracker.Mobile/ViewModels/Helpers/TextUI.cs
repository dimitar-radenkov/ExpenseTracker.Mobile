namespace ExpenseTracker.Mobile.ViewModels.Helpers
{
    public class TextUI : BaseViewModel
    {
        private string text;
        public string Text
        {
            get { return this.text; }
            set { this.SetValue(ref this.text, value); }
        }

        public TextUI()
        {
            this.Text = "";
        }
    }
}
