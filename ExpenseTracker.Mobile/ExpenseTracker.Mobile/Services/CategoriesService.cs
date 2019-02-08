using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Mobile.Models;

namespace ExpenseTracker.Mobile.Services
{
    public class CategoriesService : ICategoriesService
    {
        private List<Category> categories;

        public CategoriesService()
        {
            this.categories = new List<Category>
            {
                new Category{ Id = 1, Name = "Car", ImageUrl = "car.png" },
                new Category{ Id = 2, Name = "Home", ImageUrl = "home.png" },
                new Category{ Id = 4, Name = "Grocery", ImageUrl = "grocery.png" }
            };
        }

        public IEnumerable<Category> GetCategories()
        {
            return this.categories;
        }

        public string GetUrl(int id)
        {
            return this.categories.FirstOrDefault(x => x.Id == id).ImageUrl ?? null;
        }
    }
}