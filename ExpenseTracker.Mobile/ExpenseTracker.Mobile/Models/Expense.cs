namespace ExpenseTracker.Mobile.Models
{

    public class Expense
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}