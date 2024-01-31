using ExpenseService.Domain.Models;

namespace ExpenseService.Buiseness.UseCases.Expenses.Reponses
{
    public class ExpenseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public decimal Value { get; set; } = 0;
        public DateTime ExpenseDate { get; set; } = DateTime.UtcNow;
        public int ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; } = "";
        public int AccountId { get; set; }
        public bool Paid { get; set; } = false;
        public DateTime? PaidAt { get; set; }

        public static implicit operator ExpenseResponse(Expense expense)
        {
            return new ExpenseResponse
            {
                Id = expense.Id,
                Name = expense.Name,
                Description = expense.Description,
                Value = expense.Value,
                ExpenseDate = expense.ExpenseDate,
                ExpenseTypeId = expense.ExpenseTypeId,
                ExpenseTypeName = expense.ExpenseType?.Name ?? "",
                AccountId = expense.AccountId,
                Paid = expense.Paid,
                PaidAt = expense.PaidAt
            };
        }
    }
}
