using AutoMapper;
using finance_api.Dtos;
using finance_api.Models;
using finance_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace finance_api.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService; 
        private readonly IMapper _mapper; // Inyectar el mapper si es necesario

        // Constructor que inyecta el servicio de IncomeService
        public IncomeController(IIncomeService incomeService, IMapper mapper)
        {
            _incomeService = incomeService;
            _mapper = mapper; // Asignar el mapper
        }

        [HttpGet("api/incomes")]
        public async Task<IActionResult> GetAll()
        {
            var incomes = await _incomeService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<IncomeDto>>(incomes); // Mapear a DTOs si es necesario
            return Ok(result);
        }

        [HttpGet("api/incomes/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var income = await _incomeService.GetByIdAsync(id);
            return income is null ? NotFound() : Ok(_mapper.Map<IncomeDto>(income));
        }

        [HttpPost("api/incomes/create")]
        public async Task<IActionResult> Create([FromBody] CreateIncomeDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Income cannot be null");
            }
            var income = _mapper.Map<Income>(dto); // Mapear desde DTO a modelo        
            income.CreateDate = DateTime.Now;  // Set the creation date to now
            var createdIncome = await _incomeService.CreateAsync(income);
            return CreatedAtAction(nameof(GetById), new { id = createdIncome.Id }, _mapper.Map<IncomeDto>(createdIncome));
        }

        [HttpPut("api/incomes/update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] IncomeDto dto)
        {
            var existingIncome = await _incomeService.GetByIdAsync(id);
            if (existingIncome == null)
            {
                return NotFound();
            }
            existingIncome.Source = dto.Source;  // Update the source 
            existingIncome.Amount = dto.Amount;          // Update the amount    
            existingIncome.UpdateDate = DateTime.Now; // Update the modification date
            var updatedIncome = _mapper.Map<Income>(dto); // Map from DTO to model
            await _incomeService.UpdateAsync(updatedIncome);
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
