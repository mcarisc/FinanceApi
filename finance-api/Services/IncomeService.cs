using finance_api.Interfaces;
using finance_api.Models;
using Microsoft.EntityFrameworkCore;

namespace finance_api.Services
{
    public class IncomeService : IIncomeService
    {
        //Aplica SRP y DIP: los servicios no saben nada del DbContext directamente, solo usan el repositorio.
        private readonly IGenericRepository<Income> _repository;  

        public IncomeService(IGenericRepository<Income> repository)
        {
            _repository = repository;
        }

        public Task<Income> CreateAsync(Income income) => _repository.AddAsync(income);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
        public Task<IEnumerable<Income>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Income?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task UpdateAsync(Income income) => _repository.UpdateAsync(income);
    }
}
