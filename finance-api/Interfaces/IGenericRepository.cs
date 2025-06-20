namespace finance_api.Interfaces
{
    /* IGenericRepository interface defines the contract for a generic repository.
     * It provides methods for basic CRUD operations that can be implemented for any entity type.
     * This allows for code reuse and consistency across different repositories in the application.
     * Principios aplicados:
        Interface Segregation (solo define lo que necesitas)
        Dependency Inversion (trabajaremos contra interfaces, no implementaciones concretas)
     */
    public interface IGenericRepository<T> where T : class
    {
        // Generic repository interface for CRUD operations
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }   
}
