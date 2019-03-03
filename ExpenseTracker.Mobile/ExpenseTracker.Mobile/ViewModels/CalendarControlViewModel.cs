using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ExpenseTracker.Mobile.Extensions;
using ExpenseTracker.Mobile.Factories;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.ViewModels.Helpers;
using Prism.Mvvm;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class CalendarControlViewModel : BindableBase
    {
        private const int WeekDaysCount = 7;
        private readonly IDateTimeService dateTimeService;
        private readonly IViewModelsFactory viewModelsFactory;

        private int selectedPosition;
        public int SelectedPosition
        {
            get => this.selectedPosition;
            set => this.SetProperty(ref this.selectedPosition, value);
        }

        public TextUI Month { get; set; }

        public CollectionUI<WeekViewModel> Weeks { get; set; }

        public ICommand PositionSelectedCommand { get; set; }

        public CalendarControlViewModel(
            IDateTimeService dateTimeService, 
            IViewModelsFactory viewModelsFactory)
        {
            this.dateTimeService = dateTimeService;
            this.viewModelsFactory = viewModelsFactory;

            this.Initialize();
        }       

        private void Initialize()
        {
            this.Month = new TextUI() { Text = this.dateTimeService.UtcNow.GetMonth()  };

            var weekDates = this.GetCurrentWeek();

            var prevWeek = this.viewModelsFactory.Create(weekDates.Select(x => x.AddDays(-WeekDaysCount)).ToList());
            prevWeek.SelectedDateChanged += this.OnSelectedDateChanged;

            var currentWeek = this.viewModelsFactory.Create(weekDates);
            currentWeek.SelectedDateChanged += this.OnSelectedDateChanged;

            var nextWeek = this.viewModelsFactory.Create(weekDates.Select(x => x.AddDays(WeekDaysCount)).ToList());
            nextWeek.SelectedDateChanged += this.OnSelectedDateChanged;

            this.Weeks = new CollectionUI<WeekViewModel>(new List<WeekViewModel>
            {
                prevWeek, currentWeek, nextWeek
            });

            this.SelectedPosition = 1;
            this.PositionSelectedCommand = new Command(this.OnPositonSelected);
        }

        private void OnSelectedDateChanged(object sender, DateTime e)
        {
            this.Month.Text = e.GetMonth();
        }

        private void OnPositonSelected(object obj)
        {
            if (this.SelectedPosition == 0)
            {
                var lastWeek = this.Weeks.Items.First();
                
                var prevWeek = Enumerable.Range(1, 7)
                    .Select(x => lastWeek.StartDate.AddDays(-x))
                    .OrderBy(x => x.Date)
                    .ToList();

                var weekVM = this.viewModelsFactory.Create(prevWeek);
                weekVM.SelectedDateChanged += this.OnSelectedDateChanged;
                weekVM.DayClickedCommand.Execute(weekVM.Mon);

                this.Weeks.Items.Insert(0, weekVM);
            }

            if (this.SelectedPosition == this.Weeks.Items.Count - 1)
            {
                var nextWeek = this.Weeks.Items.Last();
                var prevWeek = Enumerable.Range(1, 7)
                    .Select(x => nextWeek.EndDate.AddDays(x))
                    .OrderBy(x => x.Date)
                    .ToList();

                var weekVM = this.viewModelsFactory.Create(prevWeek);
                weekVM.SelectedDateChanged += this.OnSelectedDateChanged;
                weekVM.DayClickedCommand.Execute(weekVM.Mon);

                this.Weeks.Items.Add(weekVM);
            }
        }

        private IEnumerable<DateTime> GetCurrentWeek()
        {
            var weekDays = new SortedSet<DateTime>();
            var today = this.dateTimeService.UtcNow;

            weekDays.Add(today);

            //get prev days till the begining of the week
            DateTime prevDate = today.AddDays(-1);
            while (prevDate.DayOfWeek > DayOfWeek.Sunday)
            {
                weekDays.Add(prevDate);
                prevDate = prevDate.AddDays(-1);
            }

            //get next days till the end of week
            DateTime nextDate = today.AddDays(1);
            while (nextDate.DayOfWeek < DayOfWeek.Sunday)
            {
                weekDays.Add(nextDate);
                nextDate = nextDate.AddDays(1);
            }

            return weekDays;
        }
    }
}
