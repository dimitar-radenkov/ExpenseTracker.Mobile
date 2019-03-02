using System;
using System.Collections.Generic;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.ViewModels;

namespace ExpenseTracker.Mobile.Factories
{
    public class ViewModelsFactory : IViewModelsFactory
    {
        private readonly IDateTimeService dateTimeService;

        public ViewModelsFactory(IDateTimeService dateTimeService)
        {
            this.dateTimeService = dateTimeService;
        }

        public WeekViewModel Create(IEnumerable<DateTime> dates) =>
            new WeekViewModel(this.dateTimeService, dates);
    }
}