using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.ViewModels.Helpers;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels
{

    public class WeekViewModel
    {
        private Dictionary<DayOfWeek, TextUI> days;
        private readonly IDateTimeService dateTimeService;

        public ICommand DayClickedCommand { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TextUI Mon { get; set; }
        public TextUI Tue { get; set; }
        public TextUI Wed { get; set; }
        public TextUI Thu { get; set; }
        public TextUI Fri { get; set; }
        public TextUI Sat { get; set; }
        public TextUI Sun { get; set; }

        public WeekViewModel(
            IDateTimeService dateTimeService, 
            IEnumerable<DateTime> dates)
        {
            this.dateTimeService = dateTimeService;

            this.Initialize();

            foreach (var date in dates)
            {
                this.days[date.DayOfWeek].Text = date.Day.ToString();

                if (date.Month != this.dateTimeService.UtcNow.Month)
                {
                    this.days[date.DayOfWeek].Opacity = 0.6;
                }

                if (date.Day == this.dateTimeService.UtcNow.Day &&
                    date.Month == this.dateTimeService.UtcNow.Month && 
                    date.Year == this.dateTimeService.UtcNow.Year)
                {
                    this.days[date.DayOfWeek].TextColor = Color.Blue;
                }
            }

            this.StartDate = dates.First();
            this.EndDate = dates.Last();
        }

        private void Initialize()
        {
            this.Mon = new TextUI();
            this.Tue = new TextUI();
            this.Wed = new TextUI();
            this.Thu = new TextUI();
            this.Fri = new TextUI();
            this.Sat = new TextUI(); 
            this.Sun = new TextUI();

            this.days = new Dictionary<DayOfWeek, TextUI>()
            {
                {  DayOfWeek.Monday, this.Mon },
                {  DayOfWeek.Tuesday, this.Tue },
                {  DayOfWeek.Wednesday, this.Wed },
                {  DayOfWeek.Thursday, this.Thu },
                {  DayOfWeek.Friday, this.Fri },
                {  DayOfWeek.Saturday, this.Sat },
                {  DayOfWeek.Sunday, this.Sun },
            };

            this.DayClickedCommand = new Command(this.OnDayClicked);
        }

        private void OnDayClicked(object obj)
        {
            if (obj is TextUI textUI)
            {
                this.days.Values.ToList().ForEach( x => x.Background = Color.Transparent);
                textUI.Background = Color.LightGreen;
            }
        }
    }
}