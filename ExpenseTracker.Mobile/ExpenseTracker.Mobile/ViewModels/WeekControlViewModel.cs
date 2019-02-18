using System;
using System.Collections.Generic;
using ExpenseTracker.Mobile.ViewModels.Helpers;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class WeekControlViewModel
    {
        public CollectionUI<WeekViewModel> Weeks { get; set; }

        public WeekControlViewModel()
        {
            this.Weeks = new CollectionUI<WeekViewModel>(new List<WeekViewModel>
            {
                new WeekViewModel(),
                new WeekViewModel(),
                new WeekViewModel(),
                new WeekViewModel(),
            });
        }
    }

    public class WeekViewModel
    {
        private Dictionary<DayOfWeek, TextUI> days;

        public TextUI Mon { get; set; }
        public TextUI Tue { get; set; }
        public TextUI Wed { get; set; }
        public TextUI Thu { get; set; }
        public TextUI Fri { get; set; }
        public TextUI Sat { get; set; }
        public TextUI Sun { get; set; }

        public WeekViewModel()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.Mon = new TextUI() { Text = "1" };
            this.Tue = new TextUI() { Text = "2" };
            this.Wed = new TextUI() { Text = "3" };
            this.Thu = new TextUI() { Text = "4" };
            this.Fri = new TextUI() { Text = "5" };
            this.Sat = new TextUI() { Text = "6" };
            this.Sun = new TextUI() { Text = "7" };

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
        }
    }
}
