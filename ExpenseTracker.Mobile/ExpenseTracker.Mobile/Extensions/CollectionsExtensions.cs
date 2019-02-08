using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExpenseTracker.Mobile.Extensions
{
    public static class CollectionsExtensions
    {
        public static void AddRange<T>(
            this ObservableCollection<T> observableCollection,
            IEnumerable<T> rangeList)
        {
            foreach (T item in rangeList)
            {
                observableCollection.Add(item);
            }
        }
    }
}
