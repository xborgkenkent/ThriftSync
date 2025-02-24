using Microsoft.EntityFrameworkCore;
using ThriftSync.Domain.Entities;
using ThriftSync.Domain.Interfaces;
using ThriftSync.Infrastructure.Data;

namespace ThriftSync.Infrastructure.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly AppDbContext _context;

    public ExpenseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Expense> AddExpenseAsync(Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
        return expense;
    }

    public async Task<IEnumerable<Expense>> GetExpensesAsync()
    {
        var expenses = await _context.Expenses.ToListAsync();
        return expenses;
    }

    public async Task<Expense?> GetExpenseByUserIdAndExpenseIdAsync(Guid userId, Guid expenseId)
    {
        var expense = await _context.Expenses.FindAsync(expenseId);
        return expense;
    }

    public async Task<IEnumerable<Expense>> GetExpensesByUserIdAsync(Guid userId)
    {
        var expenses = await _context.Expenses.Where(x => x.UserId == userId).ToListAsync();
        return expenses;
    }

    public async Task<IEnumerable<Expense>> GetExpensesByCategoryIdAsync(Guid categoryId)
    {
        var expenses = await _context.Expenses.Where(x => x.CategoryId == categoryId).OrderBy(x => x.Date).ToListAsync();
        return expenses;
    }

    public async Task<IEnumerable<Expense>> GetExpensesByUserIdAndCategoryIdAsync(Guid userId, Guid categoryId)
    {
        var expenses = await _context.Expenses.Where(x => x.UserId == userId && x.CategoryId == categoryId).OrderBy(x => x.Date).ToListAsync();
        return expenses;
    }

    public Task UpdateExpenseAsync(Expense expense)
    {
        throw new NotImplementedException();
    }

    public Task DeleteExpenseAsync(Expense expense)
    {
        throw new NotImplementedException();
    }
}