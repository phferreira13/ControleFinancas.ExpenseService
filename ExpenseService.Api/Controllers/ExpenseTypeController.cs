using ApiResult.Models;
using ExpenseService.Buiseness.UseCases.Expenses.Queries;
using ExpenseService.Buiseness.UseCases.ExpenseTypes.Commands;
using ExpenseService.Buiseness.UseCases.ExpenseTypes.Queries;
using ExpenseService.Buiseness.UseCases.ExpenseTypes.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseService.Api.Controllers
{
    [ApiController]
    [Route("api/expense-types")]
    public class ExpenseTypeController(IMediator mediator)
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<ExpenseTypeResponse>), 200)]
        public async Task<ApiResult<ExpenseTypeResponse>> AddExpenseType([FromBody] AddExpenseTypeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<IEnumerable<ExpenseTypeResponse>>), 200)]
        public async Task<ApiResult<IEnumerable<ExpenseTypeResponse>>> GetExpenseTypes([FromQuery] GetExpenseTypeByFilter query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult<ExpenseTypeResponse>), 200)]
        public async Task<ApiResult<ExpenseTypeResponse>> GetExpenseTypeById(int id)
        {
            return await _mediator.Send(new GetExpenseTypeByIdQuery { Id = id });
        }
    }
}
