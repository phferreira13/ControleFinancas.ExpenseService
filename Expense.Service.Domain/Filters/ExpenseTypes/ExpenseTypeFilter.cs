using ExpenseService.Domain.Enums;
using ExpenseService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Filters.ExpenseTypes
{
    public class ExpenseTypeFilter : IQueryFilter<ExpenseType>
    {
        public IEnumerable<int> Ids { get; set; } = Enumerable.Empty<int>();
        public string? Name { get; set; }
        public int? UserId { get; set; }
        public List<EEntityStatus>? Status { get; set; } = [EEntityStatus.Active];

        public IQueryable<ExpenseType> ApplyFilterTo(IQueryable<ExpenseType> query)
        {
            if (Ids.Any())
                query = query.Where(e => Ids.Contains(e.Id));

            if (!string.IsNullOrEmpty(Name))
                query = query.Where(e => e.Name == Name);

            if (UserId.HasValue)
                query = query.Where(e => e.UserId == UserId);

            if (Status != null && Status.Count != 0)
                query = query.Where(e => Status.Contains(e.Status));

            return query;
        }
    }
}
