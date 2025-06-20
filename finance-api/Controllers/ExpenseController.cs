using finance_api.Models;
using finance_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace finance_api.Controllers
{
    public class ExpenseController : Controller
    {
        // Aquí podrías inyectar un servicio de ExpenseService si lo necesitas
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet("api/expenses")]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await _expenseService.GetAllAsync();
            return Ok(expenses);
        }

        [HttpGet("api/expenses/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expense = await _expenseService.GetByIdAsync(id);
            return expense is null ? NotFound() : Ok(expense);
        }

        [HttpPost("api/expenses/create")]
        public async Task<IActionResult> Create([FromBody] Expense expense)
        {
            if (expense == null)
            {
                return BadRequest("Expense cannot be null");
            }
            expense.CreateDate = DateTime.Now;  
            var createdExpense = await _expenseService.CreateAsync(expense);
            return CreatedAtAction(nameof(GetById), new { id = createdExpense.Id }, createdExpense);
        }

        [HttpPut("api/expenses/update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Expense expense)
        {
            var existingExpense = await _expenseService.GetByIdAsync(id);
            if (existingExpense == null)
            {
                return NotFound();
            }            
            existingExpense.Description = expense.Description;  
            existingExpense.Amount = expense.Amount;         
            existingExpense.UpdateDate = DateTime.Now;

            await _expenseService.UpdateAsync(existingExpense);
            return NoContent();
        }

        [HttpDelete("api/expenses/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var expense = await _expenseService.GetByIdAsync(id);
            if (expense is null)
            {
                return NotFound();
            }

            await _expenseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
