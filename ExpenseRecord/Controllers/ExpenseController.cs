using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using Expense.Models;
using Expense.Services;

namespace ExpenseRecord.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    public class ExpenseRecordController : ControllerBase
    {
        private readonly IExpenseService _ExpenseService;
        private readonly ILogger<ExpenseRecordController> _logger;


        public ExpenseRecordController(IExpenseService InMemoryExpenseRecordService, ILogger<ExpenseRecordController> logger)
        {
            _ExpenseService = InMemoryExpenseRecordService;
            _logger = logger;

        }


        [HttpGet]
        [ProducesResponseType(typeof(List<Dto>), 200)]
        [ProducesResponseType(500)]
        [SwaggerOperation(
            Summary = "Get All",
            Description = "Get all to-do items"
            )]
        public async Task<ActionResult<List<Dto>>> GetAsync()
        {
            var result = await _ExpenseService.GetAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Dto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [SwaggerOperation(
            Summary = "Get By Id",
            Description = "Get to-do item by id"
            )]
        public async Task<ActionResult<Dto>> GetAsync(string id)
        {
            var result = await _ExpenseService.GetAsync(id);
            if (result == null)
            {
                return NotFound($"The item with id {id} does not exist.");
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Dto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [SwaggerOperation(
            Summary = "Create New Item",
            Description = "Create a new to-do item"
            )]

        public async Task<ActionResult<Dto>> PostAsync([FromBody] CreateRequest ExpenseRecordCreateRequest)
        {
            var ExpenseRecordDto = new Dto
            {
                Description = ExpenseRecordCreateRequest.Description,
                Type = ExpenseRecordCreateRequest.Type,
                Amount = ExpenseRecordCreateRequest.Amount,
                CreatedTime = DateTime.Now
            };
            await _ExpenseService.CreateAsync(ExpenseRecordDto);
            return Created("", ExpenseRecordDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Dto), 200)]
        [ProducesResponseType(typeof(Dto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [SwaggerOperation(
            Summary = "Upsert Item",
            Description = "Create or replace a to-do item by id"
            )]
        public async Task<ActionResult<Dto>> PutAsync(string id, [FromBody] Dto ExpenseRecordDto)
        {
            bool isCreate = false;
            var existingItem = await _ExpenseService.GetAsync(id);
            if (existingItem is null)
            {
                isCreate = true;
                await _ExpenseService.CreateAsync(ExpenseRecordDto);
            }
            else
            {
                await _ExpenseService.ReplaceAsync(id, ExpenseRecordDto);
            }

            return isCreate ? Created("", ExpenseRecordDto) : Ok(ExpenseRecordDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [SwaggerOperation(
            Summary = "Delete Item",
            Description = "Delete a to-do item by id"
            )]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var isSuccessful = await _ExpenseService.RemoveAsync(id);
            if (!isSuccessful)
            {
                return NotFound($"The item with id {id} does not exist.");
            }
            _logger.LogInformation($"To-do item {id} deleted.");
            return NoContent();
        }
    }
}