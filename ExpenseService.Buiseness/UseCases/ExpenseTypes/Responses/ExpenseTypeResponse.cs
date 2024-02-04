using ExpenseService.Domain.Enums;
using ExpenseService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Buiseness.UseCases.ExpenseTypes.Responses
{
    public class ExpenseTypeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public EEntityStatus Status { get; set; }

        public static implicit operator ExpenseTypeResponse(ExpenseType expenseType)
        {
            if (expenseType == null)
                return null;

            return new ExpenseTypeResponse
            {
                Id = expenseType.Id,
                Name = expenseType.Name,
                Description = expenseType.Description,
                CreatedAt = expenseType.CreatedAt,
                UpdatedAt = expenseType.UpdatedAt,
                DeletedAt = expenseType.DeletedAt,
                Status = expenseType.Status
            };
        }
    }
}
