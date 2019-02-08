using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExpenseTracker.Mobile.ViewModels.Helpers
{
    public class CollectionUI<T> : TextUI
    {
        private ObservableCollection<T> items;
        private T selectedItem;

        public event EventHandler<ValueChangedEventArgs<T>> SelectedItemChanged;

        public ObservableCollection<T> Items
        {
            get { return this.items; }
            set
            {
                this.SetProperty(ref this.items, value);
            }
        }

        public T SelectedItem
        {
            get { return this.selectedItem; }
            set
            {
                var eventArgs = new ValueChangedEventArgs<T>(this.selectedItem, value);
                if (this.SetProperty(ref this.selectedItem, value))
                {
                    this.SelectedItemChanged?.Invoke(this, eventArgs);
                }
            }
        }

        public CollectionUI()
            :this(new List<T>())
        {
        }         

        public CollectionUI(IEnumerable<T> items)
        {
            this.items = new ObservableCollection<T>(items);
            this.selectedItem = default(T);
        }
    }
}
