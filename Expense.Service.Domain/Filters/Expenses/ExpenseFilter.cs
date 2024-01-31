using ExpenseService.Domain.Enums;
using ExpenseService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Filters.Expenses
{
    public class ExpenseFilter
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ExpenseTypeId { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public EEntityStatus? Status { get; set; } = EEntityStatus.Active;

        public IQueryable<Expense> ApplyFilter(IQueryable<Expense> query)
        {
            if (!string.IsNullOrEmpty(Name))
                query = query.Where(e => e.Name == Name);

            if (!string.IsNullOrEmpty(Description))
                query = query.Where(e => e.Description == Description);

            if (ExpenseTypeId.HasValue)
                query = query.Where(e => e.ExpenseTypeId == ExpenseTypeId);

            if (ExpenseDate.HasValue)
                query = query.Where(e => e.ExpenseDate == ExpenseDate);

            if (Status.HasValue)
                query = query.Where(e => e.Status == Status);

            return query;
        }
    }
}
