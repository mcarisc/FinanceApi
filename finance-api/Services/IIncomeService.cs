using finance_api.Models;

namespace finance_api.Services
{
    public interface IIncomeService
    {
        /// <summary>
        /// Retrieves all income records.
        /// </summary>
        /// <returns>A list of all income records.</returns>
        Task<IEnumerable<Income>> GetAllAsync();

        /// <summary>
        /// Retrieves an income record by its ID.
        /// </summary>
        /// <param name="id">The ID of the income record.</param>
        /// <returns>The income record if found, otherwise null.</returns>
        Task<Income?> GetByIdAsync(int id);

        /// <summary>
        /// Adds a new income record.
        /// </summary>
        /// <param name="income">The income record to add.</param>
        /// <returns>The added income record.</returns>
        Task<Income> CreateAsync(Income income);

        /// <summary>
        /// Updates an existing income record.
        /// </summary>
        /// <param name="income">The income record with updated values.</param>
        Task UpdateAsync(Income income);

        /// <summary>
        /// Deletes an income record by its ID.
        /// </summary>
        /// <param name="id">The ID of the income record to delete.</param>
        Task DeleteAsync(int id);
    }
}
