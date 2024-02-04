using ApiResult.Models;
using ExpenseService.Buiseness.UseCases.ExpenseTypes.Responses;
using ExpenseService.Domain.Enums;
using ExpenseService.Domain.Filters.ExpenseTypes;
using ExpenseService.Domain.Interface.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseService.Buiseness.UseCases.ExpenseTypes.Queries
{
    public class GetExpenseTypeByFilter : IRequest<ApiResult<IEnumerable<ExpenseTypeResponse>>>
    {
        public string? Name { get; set; }
        public int? UserId { get; set; }
        public List<EEntityStatus>? Status { get; set; } = [EEntityStatus.Active];

        public static implicit operator ExpenseTypeFilter(GetExpenseTypeByFilter query)
        {
            return new ExpenseTypeFilter
            {
                Name = query.Name,
                UserId = query.UserId,
                Status = query.Status
            };
        }

        internal class GetExpenseTypeHandler(IExpenseTypeRepository expenseTypeRepository) : IRequestHandler<GetExpenseTypeByFilter, ApiResult<IEnumerable<ExpenseTypeResponse>>>
        {
            private readonly IExpenseTypeRepository _expenseTypeRepository = expenseTypeRepository;

            public async Task<ApiResult<IEnumerable<ExpenseTypeResponse>>> Handle(GetExpenseTypeByFilter request, CancellationToken cancellationToken)
            {
                var apiResult = new ApiResult<IEnumerable<ExpenseTypeResponse>>();
                await apiResult.ExecuteAsync(async () =>
                {
                    return (await _expenseTypeRepository.GetExpenseTypesByFilterAsync(request))
                        .ToList()
                        .ConvertAll<ExpenseTypeResponse>(e => e);
                });
                return apiResult;
            }
        }
    }
}
