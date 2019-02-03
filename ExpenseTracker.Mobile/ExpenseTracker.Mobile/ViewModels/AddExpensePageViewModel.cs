using System.Collections.ObjectModel;
using ExpenseTracker.Mobile.Models;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.ViewModels.Helpers;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class AddExpensePageViewModel : BaseViewModel
    {
        private readonly ICategoriesService categoriesService;

        public TextUI Description { get; set; }
        public TextUI Amount { get; set; }
        public ObservableCollection<Category> CategoriesList { get; set; }

        public AddExpensePageViewModel(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;

            this.Initialize();
        }

        private void Initialize()
        {
            this.Description = new TextUI();
            this.Amount = new TextUI();
            this.CategoriesList = new ObservableCollection<Category>(this.categoriesService.GetCategories());
        }
    }
}
