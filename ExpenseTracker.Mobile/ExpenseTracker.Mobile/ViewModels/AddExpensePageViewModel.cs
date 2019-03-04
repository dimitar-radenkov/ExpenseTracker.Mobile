using System;
using System.Linq;
using ExpenseTracker.Mobile.Events;
using ExpenseTracker.Mobile.Models;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.Storage;
using ExpenseTracker.Mobile.ViewModels.Helpers;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class AddExpensePageViewModel : BindableBase
    {
        private readonly ExpenseTrackerDbContext db;
        private readonly ICategoriesService categoriesService;
        private readonly INavigationService navigationService;
        private readonly IDateTimeService dateTimeService;
        private readonly IEventAggregator eventAggregator;

        public DateUI SelectedDate { get; set; }
        public TextUI Description { get; set; }
        public TextUI Amount { get; set; }
        public CollectionUI<Category> CategoriesList { get; set; }
        public ButtonUI SaveButton { get; set; }

        public AddExpensePageViewModel(
            ExpenseTrackerDbContext db,
            ICategoriesService categoriesService,
            INavigationService navigationService,
            IDateTimeService dateTimeService,
            IEventAggregator eventAggregator)
        {
            this.db = db;
            this.categoriesService = categoriesService;
            this.navigationService = navigationService;
            this.dateTimeService = dateTimeService;
            this.eventAggregator = eventAggregator;

            this.Initialize();
        }

        private void Initialize()
        {
            this.SelectedDate = new DateUI() { DateTime = this.dateTimeService.UtcNow };
            this.Description = new TextUI();

            this.Amount = new TextUI();
            this.Amount.TextChanged += (s, e) => this.SaveButton.IsEnabled = !string.IsNullOrWhiteSpace(e.NewValue);

            this.CategoriesList = new CollectionUI<Category>(this.categoriesService.GetCategories());
            this.CategoriesList.SelectedItem = this.CategoriesList.Items.First();

            this.SaveButton = new ButtonUI(new Command(this.OnButtonSaveClick));
            this.SaveButton.IsEnabled = false; 
        }

        private async void OnButtonSaveClick()
        {
            var expense = new Expense
            {
                Description = this.Description.Text,
                Amount = decimal.Parse(this.Amount.Text),
                CreationDate = this.dateTimeService.UtcNow,
                ExecutionDate = this.SelectedDate.DateTime,
                CategoryId = this.CategoriesList.SelectedItem.Id,
            };

            this.db.Expenses.Add(expense);
            this.db.SaveChanges();

            await this.navigationService.GoBackAsync();

            this.eventAggregator
                .GetEvent<ExpenseAddedEvent>()
                .Publish();
        }
    }
}
