using System;
using System.Linq;
using ExpenseTracker.Mobile.Models;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.Storage;
using ExpenseTracker.Mobile.ViewModels.Helpers;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class AddExpensePageViewModel : BaseViewModel
    {
        private readonly ICategoriesService categoriesService;
        private readonly IPageService pageService;
        private readonly IDbService dbService;

        public TextUI Description { get; set; }
        public TextUI Amount { get; set; }
        public CollectionUI<Category> CategoriesList { get; set; }
        public ButtonUI SaveButton { get; set; }

        public AddExpensePageViewModel(
            ICategoriesService categoriesService, 
            IPageService pageService,
            IDbService dbService)
        {
            this.categoriesService = categoriesService;
            this.pageService = pageService;
            this.dbService = dbService;

            this.Initialize();
        }

        private void Initialize()
        {
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
                CreationDate = DateTime.UtcNow,
                CategoryId = this.CategoriesList.SelectedItem.Id,
            };

            this.dbService.GetContext().Expenses.Add(expense);
            await this.dbService.GetContext().SaveChangesAsync();
            await this.pageService.PopAsync();
        }
    }
}
