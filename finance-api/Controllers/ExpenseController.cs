using AutoMapper;
using finance_api.Dtos;
using finance_api.Models;
using finance_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace finance_api.Controllers
{
    public class ExpenseController : Controller
    {
        // Aquí podrías inyectar un servicio de ExpenseService si lo necesitas
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper; // Inyectar el mapper si es necesario

        // Constructor que inyecta el servicio de ExpenseService
        public ExpenseController(IExpenseService expenseService, IMapper mapper)
        {
            _expenseService = expenseService;
            _mapper = mapper;   
        }

        [HttpGet("api/expenses")]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await _expenseService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<ExpenseDto>>(expenses); // Mapear a DTOs si es necesario
            return Ok(result);
        }

        [HttpGet("api/expenses/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expense = await _expenseService.GetByIdAsync(id);
            return expense is null ? NotFound() : Ok(_mapper.Map<ExpenseDto>(expense));
        }

        [HttpPost("api/expenses/create")]
        public async Task<IActionResult> Create([FromBody] ExpenseDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Expense cannot be null");
            }
            dto.CreateDate = DateTime.Now;  
            var expense = _mapper.Map<Expense>(dto); // Mapear desde DTO a modelo
            var createdExpense = await _expenseService.CreateAsync(expense);
            return CreatedAtAction(nameof(GetById), new { id = createdExpense.Id }, _mapper.Map<ExpenseDto>(createdExpense));
        }

        [HttpPut("api/expenses/update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ExpenseDto dto)
        {
            var existingExpense = await _expenseService.GetByIdAsync(id);
            if (existingExpense == null)
            {
                return NotFound();
            }            
            existingExpense.Description = dto.Description;  
            existingExpense.Amount = dto.Amount;         
            existingExpense.UpdateDate = DateTime.Now;
            var updatedExpense = _mapper.Map<Expense>(existingExpense); // Map from DTO to model
            await _expenseService.UpdateAsync(updatedExpense);
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
