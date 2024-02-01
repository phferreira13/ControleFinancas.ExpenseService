using ApiResult.Models;
using ExpenseService.Buiseness.UseCases.Expenses.Commands;
using ExpenseService.Buiseness.UseCases.Expenses.Queries;
using ExpenseService.Buiseness.UseCases.Expenses.Reponses;
using ExpenseService.Domain.Filters.Expenses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseService.Api.Controllers
{
    [Route("api/expenses")]
    [ApiController]
    public class ExpenseController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<IEnumerable<ExpenseResponse>>), 200)]
        public async Task<ApiResult<IEnumerable<ExpenseResponse>>> GetExpenses([FromQuery] GetExpensesByFilterQuery query)
        {
            return await _mediator.Send(query);            
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<ExpenseResponse>), 200)]
        public async Task<ApiResult<ExpenseResponse>> AddExpense([FromBody] AddExpenseCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
