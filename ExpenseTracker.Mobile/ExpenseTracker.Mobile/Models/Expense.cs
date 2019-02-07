using System;

namespace ExpenseTracker.Mobile.Models
{
    public class Expense
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}