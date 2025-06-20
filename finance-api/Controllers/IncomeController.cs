using finance_api.Models;
using finance_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace finance_api.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService; 
        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet("api/incomes")]
        public async Task<IActionResult> GetAll()
        {
            var incomes = await _incomeService.GetAllAsync();
            return Ok(incomes);
        }

        [HttpGet("api/incomes/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var income = await _incomeService.GetByIdAsync(id);
            return income is null ? NotFound() : Ok(income);
        }

        [HttpPost("api/incomes/create")]
        public async Task<IActionResult> Create([FromBody] Income income)
        {
            if (income == null)
            {
                return BadRequest("Income cannot be null");
            }
            income.CreateDate = DateTime.Now;  // Set the creation date to now
            var createdIncome = await _incomeService.CreateAsync(income);
            return CreatedAtAction(nameof(GetById), new { id = createdIncome.Id }, createdIncome);
        }

        [HttpPut("api/incomes/update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Income income)
        {
            var existingIncome = await _incomeService.GetByIdAsync(id);
            if (existingIncome == null)
            {
                return NotFound();
            }
            existingIncome.Source = income.Source;  // Update the description 
            existingIncome.Amount = income.Amount;          // Update the amount    
            existingIncome.UpdateDate = DateTime.Now; // Update the modification date   
            await _incomeService.UpdateAsync(existingIncome);
            return NoContent();
        }

        [HttpDelete("api/incomes/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var income = await _incomeService.GetByIdAsync(id);
            if (income is null)
            {
                return NotFound();
            }

            await _incomeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
