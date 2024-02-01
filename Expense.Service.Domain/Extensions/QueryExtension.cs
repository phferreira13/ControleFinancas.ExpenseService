using ExpenseService.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Domain.Extensions
{
    public static class QueryExtension
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, IQueryFilter<T> filter) where T : class
        {
            return filter.ApplyFilterTo(query);
        }
    }
}
