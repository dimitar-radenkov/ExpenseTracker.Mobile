using System;
using System.Collections.Generic;
using ExpenseTracker.Mobile.ViewModels;

namespace ExpenseTracker.Mobile.Factories
{
    public interface IViewModelsFactory
    {
        WeekViewModel Create(IEnumerable<DateTime> dates);
    }
}
