using System;

namespace ExpenseTracker.Mobile.ViewModels.Helpers
{
    public class ValueChangedEventArgs<T> :EventArgs
    {
        public T OldValue { get; }
        public T NewValue { get; }

        public ValueChangedEventArgs(T oldValue, T newValue)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
    }
}
