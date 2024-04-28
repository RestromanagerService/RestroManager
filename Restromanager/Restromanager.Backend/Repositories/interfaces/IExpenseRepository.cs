using Restromanager.Backend.Domain.Entities;

namespace Restromanager.Backend.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        Task<Expense> GetByIdAsync(int id, bool includeRelated = false);
        Task<IEnumerable<Expense>> GetAllAsync(bool includeRelated = false);
        Task<Expense> CreateAsync(Expense expense);
        Task<bool> UpdateAsync(Expense expense);
        Task<bool> DeleteAsync(int id);
    }
}


