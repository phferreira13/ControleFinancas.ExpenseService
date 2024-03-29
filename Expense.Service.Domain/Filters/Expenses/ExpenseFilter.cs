﻿using ExpenseService.Domain.Enums;
using ExpenseService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Filters.Expenses
{
    public class ExpenseFilter : IQueryFilter<Expense>
    {
        public IEnumerable<int> Ids { get; set; } = Enumerable.Empty<int>();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ExpenseTypeId { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public List<EEntityStatus>? Status { get; set; } = [EEntityStatus.Active];

        public IQueryable<Expense> ApplyFilterTo(IQueryable<Expense> query)
        {
            if (Ids.Any())
                query = query.Where(e => Ids.Contains(e.Id));

            if (!string.IsNullOrEmpty(Name))
                query = query.Where(e => e.Name == Name);

            if (!string.IsNullOrEmpty(Description))
                query = query.Where(e => e.Description == Description);

            if (ExpenseTypeId.HasValue)
                query = query.Where(e => e.ExpenseTypeId == ExpenseTypeId);

            if (ExpenseDate.HasValue)
                query = query.Where(e => e.ExpenseDate == ExpenseDate);

            if (Status != null && Status.Count != 0)
                query = query.Where(e => Status.Contains(e.Status));

            return query;
        }
    }
}
