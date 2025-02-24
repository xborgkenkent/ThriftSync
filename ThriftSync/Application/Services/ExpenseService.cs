using ThriftSync.Domain.Entities;
using ThriftSync.Domain.Interfaces;

namespace ThriftSync.Application.Services;

public class ExpenseService
{
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseService(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public async Task<Expense> AddExpenseAsync(Expense expense)
    {
        return await _expenseRepository.AddExpenseAsync(expense);
    }

    public async Task<Expense?> GetExpenseByUserIdAndExpenseIdAsync(Guid userId, Guid expenseId)
    {
        return await _expenseRepository.GetExpenseByUserIdAndExpenseIdAsync(userId, expenseId);
    }

    public async Task<IEnumerable<Expense>> GetExpensesByUserIdAsync(Guid userId)
    {
        return await _expenseRepository.GetExpensesByUserIdAsync(userId);
    }

    
    public async Task<IEnumerable<Expense>> GetExpensesByUserIdAndCategoryIdAsync(Guid userId, Guid categoryId)
    {
        return await _expenseRepository.GetExpensesByUserIdAndCategoryIdAsync(userId, categoryId);
    }
}