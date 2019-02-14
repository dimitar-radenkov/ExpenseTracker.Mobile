using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTracker.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalendarView : ContentView
	{
		public CalendarView()
		{
			InitializeComponent();
        }

        private void OnSwipeUp(object sender, SwipedEventArgs e)
        {
            this.BackgroundColor = Color.Blue;   
        }

        private void OnSwipeDown(object sender, SwipedEventArgs e)
        {
            this.BackgroundColor = Color.Gray;
        }
    }
}