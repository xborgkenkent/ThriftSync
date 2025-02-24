using ThriftSync.Domain.Entities;

namespace ThriftSync.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category> AddCategoryAsync(Category category);
    Task<IEnumerable<Category>> GetCategoriesByUserIdAsync(Guid userId);
    Task<Category?> GetCategoryByUserIdAndCategoryIdAsync(Guid userId, Guid categoryId);
    Task<Category> UpdateCategoryAsync(Category category);
}