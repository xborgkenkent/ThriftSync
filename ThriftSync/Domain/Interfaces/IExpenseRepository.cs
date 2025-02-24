using ThriftSync.Domain.Entities;

namespace ThriftSync.Domain.Interfaces;

public interface IExpenseRepository
{
    Task<Expense> AddExpenseAsync(Expense expense);
    Task<IEnumerable<Expense>> GetExpensesAsync();
    Task<Expense?> GetExpenseByUserIdAndExpenseIdAsync(Guid userId, Guid expenseId);
    Task<IEnumerable<Expense>> GetExpensesByUserIdAsync(Guid userId);
    Task<IEnumerable<Expense>> GetExpensesByCategoryIdAsync(Guid categoryId);
    Task<IEnumerable<Expense>> GetExpensesByUserIdAndCategoryIdAsync(Guid userId, Guid categoryId);
    Task UpdateExpenseAsync(Expense expense);
    Task DeleteExpenseAsync(Expense expense);
}