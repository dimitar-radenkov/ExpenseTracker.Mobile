using System.Windows.Input;

namespace ExpenseTracker.Mobile.ViewModels.Helpers
{
    public class ButtonUI : BaseUI
    {
        public ICommand Command { get; set; }

        public ButtonUI(ICommand command)
        {
            this.Command = command;
        }
    }
}
