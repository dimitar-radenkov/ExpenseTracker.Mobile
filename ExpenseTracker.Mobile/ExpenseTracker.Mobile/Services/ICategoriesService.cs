using System.Collections.Generic;
using ExpenseTracker.Mobile.Models;

namespace ExpenseTracker.Mobile.Services
{
    public interface ICategoriesService
    {
        IEnumerable<Category> GetCategories();
    }
}
