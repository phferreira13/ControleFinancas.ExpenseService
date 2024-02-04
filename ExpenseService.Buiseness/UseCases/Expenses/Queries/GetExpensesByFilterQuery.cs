using ApiResult.Models;
using ExpenseService.Buiseness.UseCases.Expenses.Reponses;
using ExpenseService.Domain.Enums;
using ExpenseService.Domain.Filters.Expenses;
using ExpenseService.Domain.Interface.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Buiseness.UseCases.Expenses.Queries
{
    public class GetExpensesByFilterQuery : IRequest<ApiResult<IEnumerable<ExpenseResponse>>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ExpenseTypeId { get; set; }
        public DateTime? Date { get; set; }
        public List<EEntityStatus>? Status { get; set; } = [EEntityStatus.Active];

        public static implicit operator ExpenseFilter(GetExpensesByFilterQuery query)
        {
            return new ExpenseFilter
            {
                Name = query.Name,
                Description = query.Description,
                ExpenseTypeId = query.ExpenseTypeId,
                ExpenseDate = query.Date,
                Status = query.Status
            };
        }

        internal class GetExpensesQueryHandler(IExpenseRepository expenseRepository) : IRequestHandler<GetExpensesByFilterQuery, ApiResult<IEnumerable<ExpenseResponse>>>
        {
            private readonly IExpenseRepository _expenseRepository = expenseRepository;

            public async Task<ApiResult<IEnumerable<ExpenseResponse>>> Handle(GetExpensesByFilterQuery request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<IEnumerable<ExpenseResponse>>();

                await apiResult.ExecuteAsync(
                    func: async () =>
                        (await _expenseRepository.GetExpensesByFilterAsync(request))
                            .ToList().ConvertAll<ExpenseResponse>(e => e)
                );
                return apiResult;
            }
        }
    }
}
