﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
		}

		protected bool SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return false;
            }
				
			backingField = value; 
			OnPropertyChanged(propertyName);

            return true;
		}
	}
}
