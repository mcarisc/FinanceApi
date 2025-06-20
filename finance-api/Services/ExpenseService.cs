using finance_api.Interfaces;
using finance_api.Models;

namespace finance_api.Services
{
    public class ExpenseService : IExpenseService
    {
        //Aplica SRP y DIP: los servicios no saben nada del DbContext directamente, solo usan el repositorio.
        private readonly IGenericRepository<Expense> _repository;
        public ExpenseService(IGenericRepository<Expense> repository)
        {
            _repository = repository;
        }

        public Task<Expense> CreateAsync(Expense expense) => _repository.AddAsync(expense);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
        public Task<IEnumerable<Expense>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Expense?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task UpdateAsync(Expense expense) => _repository.UpdateAsync(expense);
    }
}
