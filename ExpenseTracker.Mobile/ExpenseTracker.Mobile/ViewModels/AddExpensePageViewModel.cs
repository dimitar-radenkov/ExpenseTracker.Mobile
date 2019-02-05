using ExpenseTracker.Mobile.Models;
using ExpenseTracker.Mobile.Services;
using ExpenseTracker.Mobile.ViewModels.Helpers;
using Xamarin.Forms;

namespace ExpenseTracker.Mobile.ViewModels
{
    public class AddExpensePageViewModel : BaseViewModel
    {
        private readonly ICategoriesService categoriesService;

        public TextUI Description { get; set; }
        public TextUI Amount { get; set; }
        public CollectionUI<Category> CategoriesList { get; set; }
        public ButtonUI SaveButton { get; set; }

        public AddExpensePageViewModel(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;

            this.Initialize();
        }

        private void Initialize()
        {
            this.Description = new TextUI();

            this.Amount = new TextUI();
            this.Amount.TextChanged += (s, e) => this.SaveButton.IsEnabled = !string.IsNullOrWhiteSpace(e.NewValue);

            this.CategoriesList = new CollectionUI<Category>(this.categoriesService.GetCategories());

            this.SaveButton = new ButtonUI(new Command(this.OnButtonSaveClick));
            this.SaveButton.IsEnabled = false; 
        }

        private bool Validate()
        {
            return !string.IsNullOrWhiteSpace(this.Amount.Text) && 
                this.CategoriesList.SelectedItem != null;
        }

        private void OnButtonSaveClick()
        {

        }
    }
}
