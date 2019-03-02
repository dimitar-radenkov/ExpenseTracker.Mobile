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
        private Dictionary<DayOfWeek, DateUI> days;
        private readonly IDateTimeService dateTimeService;

        public EventHandler<DateTime> SelectedDateChanged;
        public ICommand DayClickedCommand { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateUI Mon { get; set; }
        public DateUI Tue { get; set; }
        public DateUI Wed { get; set; }
        public DateUI Thu { get; set; }
        public DateUI Fri { get; set; }
        public DateUI Sat { get; set; }
        public DateUI Sun { get; set; }

        public WeekViewModel(
            IDateTimeService dateTimeService, 
            IEnumerable<DateTime> dates)
        {
            this.dateTimeService = dateTimeService;

            this.Initialize();

            foreach (var date in dates)
            {
                this.days[date.DayOfWeek].Text = date.Day.ToString();
                this.days[date.DayOfWeek].DateTime = date;

                //this month
                if (date.Month != this.dateTimeService.UtcNow.Month)
                {
                    this.days[date.DayOfWeek].Opacity = 0.6;
                }

                //today
                if (date.Day == this.dateTimeService.UtcNow.Day &&
                    date.Month == this.dateTimeService.UtcNow.Month && 
                    date.Year == this.dateTimeService.UtcNow.Year)
                {
                    this.days[date.DayOfWeek].TextColor = Color.DarkRed;
                }
            }

            this.StartDate = dates.First();
            this.EndDate = dates.Last();
        }

        private void Initialize()
        {
            this.Mon = new DateUI();
            this.Tue = new DateUI();
            this.Wed = new DateUI();
            this.Thu = new DateUI();
            this.Fri = new DateUI();
            this.Sat = new DateUI(); 
            this.Sun = new DateUI();

            this.days = new Dictionary<DayOfWeek, DateUI>()
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
            if (obj is DateUI dateUI)
            {
                this.days.Values.ToList().ForEach(x => 
                {
                    x.Background = Color.Transparent;
                    x.TextColor = Color.Black;
                });

                dateUI.Background = Color.Blue;
                dateUI.TextColor = Color.White;

                this.SelectedDateChanged?.Invoke(this, dateUI.DateTime);
            }
        }
    }
}