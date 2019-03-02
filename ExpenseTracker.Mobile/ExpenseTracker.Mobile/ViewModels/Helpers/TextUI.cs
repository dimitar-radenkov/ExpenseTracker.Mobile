using System;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels.Helpers
{
    public class TextUI : BaseUI
    {
        private string text;
        private Color textColor;
        private double opacity;
        public string Text
        {
            get => this.text;
            set
            {
                var eventArgs = new ValueChangedEventArgs<string>(this.text, value);
                if (this.SetProperty(ref this.text, value))
                {
                    this.TextChanged?.Invoke(this, eventArgs);
                }
            }
        }

        public Color TextColor
        {
            get => this.textColor;
            set => this.SetProperty(ref this.textColor, value);
        }

        public double Opacity
        {
            get => this.opacity;
            set => this.SetProperty(ref this.opacity, value);
        }

        public event EventHandler<ValueChangedEventArgs<string>> TextChanged;

        public TextUI()
        {
            this.text = string.Empty;
            this.textColor = Color.Black;
            this.opacity = 1;
        }
    }

    public class DateUI : TextUI
    {
        public DateTime DateTime { get; set; }
    }
}
