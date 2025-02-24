using Microsoft.EntityFrameworkCore;
using ThriftSync.Domain.Entities;
using ThriftSync.Domain.Interfaces;
using ThriftSync.Infrastructure.Data;

namespace ThriftSync.Infrastructure.Repositories;

public class DefaultCategoryRepository : IDefaultCategoryRepository
{
    private readonly AppDbContext _context;

    public DefaultCategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<DefaultCategory>> GetCategories()
    {
        var categories = await _context.DefaultCategories.ToListAsync();
        return categories;
    }

    public async Task<DefaultCategory?> GetCategoryById(Guid id)
    {
        var category = await _context.DefaultCategories.FirstOrDefaultAsync(c => c.Id == id);
        return category;
    }
}