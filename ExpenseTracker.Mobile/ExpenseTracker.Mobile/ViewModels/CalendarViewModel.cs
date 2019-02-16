using System.Windows.Input;
using ExpenseTracker.Mobile.ViewModels.Helpers;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class CalendarViewModel
    {
        public BaseUI Base { get; set; }

        public ICommand SwipeLeftCommand { get; set; }
        public ICommand SwipeRigthCommand { get; set; }

        public CalendarViewModel()
        {
            this.Base = new BaseUI();
            this.SwipeLeftCommand = new Command(this.OnSwipeLeft);
            this.SwipeRigthCommand = new Command(this.OnSwipeRight);
        }

        private void OnSwipeRight()
        {
            this.Base.Background = Color.Red;
        }

        private void OnSwipeLeft()
        {
            this.Base.Background = Color.Blue;
        }
    }
}
