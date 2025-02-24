using Microsoft.EntityFrameworkCore;
using ThriftSync.Domain.Entities;
using ThriftSync.Domain.Interfaces;
using ThriftSync.Infrastructure.Data;

namespace ThriftSync.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<IEnumerable<Category>> GetCategoriesByUserIdAsync(Guid userId)
    {
        var categories =  await _context.Categories.Where(x => x.UserId == userId).ToListAsync();
        return categories;
    }

    public async Task<Category?> GetCategoryByUserIdAndCategoryIdAsync(Guid userId, Guid categoryId)
    {
        var categories =  await _context.Categories.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        return categories;
    }

    public Task<Category> UpdateCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }
}