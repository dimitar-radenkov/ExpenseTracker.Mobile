using System.Collections.Generic;
using ExpenseTracker.Mobile.Models;

namespace ExpenseTracker.Mobile.Services
{
    public class CategoriesService : ICategoriesService
    {
        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category{ Id = 1, Name = "Car"},
                new Category{ Id = 2, Name = "Home"},
                new Category{ Id = 3, Name = "Utils"},
                new Category{ Id = 4, Name = "Grocery"}
            };
        }
    }
}