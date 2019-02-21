using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.ViewModels.Helpers;
using Prism.Mvvm;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class MonthControlViewModel : BindableBase
    {
        private const int WeekDaysCount = 7;
        private readonly IDateTimeService dateTimeService;

        private int selectedPosition;
        public int SelectedPosition
        {
            get => this.selectedPosition;
            set => this.SetProperty(ref this.selectedPosition, value);
        }

        public CollectionUI<WeekViewModel> Weeks { get; set; }

        public ICommand PositionSelectedCommand { get; set; }

        public MonthControlViewModel(IDateTimeService dateTimeService)
        {
            this.dateTimeService = dateTimeService;

            this.Initialize();
        }       

        private void Initialize()
        {
            var weekDates = this.GetCurrentWeek();

            this.Weeks = new CollectionUI<WeekViewModel>(new List<WeekViewModel>
            {
                new WeekViewModel(this.dateTimeService, weekDates.Select(x => x.AddDays(-WeekDaysCount))),//prev week
                new WeekViewModel(this.dateTimeService, weekDates), //current week
                new WeekViewModel(this.dateTimeService, weekDates.Select(x => x.AddDays(WeekDaysCount))) //next week
            });

            this.SelectedPosition = 1;
            this.PositionSelectedCommand = new Command(OnPositonSelected);
        }

        private void OnPositonSelected(object obj)
        {
            int a = this.SelectedPosition;
            if (this.SelectedPosition == 0)
            {
                var lastWeek = this.Weeks.Items.First();
                var prevWeek = Enumerable.Range(1, 7)
                    .Select(x => lastWeek.StartDate.AddDays(-x))
                    .OrderBy(x => x.Date)
                    .ToList();
     
                this.Weeks.Items.Insert(0, new WeekViewModel(this.dateTimeService, prevWeek));
            }

            if (this.SelectedPosition == this.Weeks.Items.Count - 1)
            {
                var nextWeek = this.Weeks.Items.Last();
                var prevWeek = Enumerable.Range(1, 7)
                    .Select(x => nextWeek.EndDate.AddDays(x))
                    .OrderBy(x => x.Date)
                    .ToList();

                this.Weeks.Items.Add(new WeekViewModel(this.dateTimeService, prevWeek));
            }
        }

        private IEnumerable<DateTime> GetCurrentWeek()
        {
            var weekDays = new SortedSet<DateTime>();
            var today = this.dateTimeService.UtcNow;

            //get prev days till the begining of the week
            DateTime prevDate = today;
            while (prevDate.DayOfWeek != DayOfWeek.Sunday)
            {
                weekDays.Add(prevDate);
                prevDate = prevDate.AddDays(-1);
            }

            //get next days till the end of week
            DateTime nextDate = today.AddDays(1);
            while (nextDate.DayOfWeek != DayOfWeek.Monday)
            {
                weekDays.Add(nextDate);
                nextDate = nextDate.AddDays(1);
            }

            return weekDays;
        }
    }
}
