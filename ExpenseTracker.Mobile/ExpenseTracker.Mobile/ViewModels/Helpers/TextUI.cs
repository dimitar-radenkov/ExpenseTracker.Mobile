using System;
using Prism.Mvvm;

namespace ExpenseTracker.Mobile.ViewModels.Helpers
{
    public class TextUI : BindableBase
    {
        private string text;
        public string Text
        {
            get { return this.text; }
            set
            {
                var eventArgs = new ValueChangedEventArgs<string>(this.text, value);
                if (this.SetProperty(ref this.text, value))
                {
                    this.TextChanged?.Invoke(this, eventArgs);
                }              
            }
        }

        public event EventHandler<ValueChangedEventArgs<string>> TextChanged;

        public TextUI()
        {
            this.text = string.Empty;
        }
    }
}
