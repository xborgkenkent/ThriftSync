using ThriftSync.Domain.Entities;
using ThriftSync.Domain.Interfaces;

namespace ThriftSync.Application.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        return await _categoryRepository.AddCategoryAsync(category);
    }

    public async Task<IEnumerable<Category>> GetCategoriesByUserIdAsync(Guid userId)
    {
        return await _categoryRepository.GetCategoriesByUserIdAsync(userId);
    }

    public async Task<Category?> GetCategoryByUserIdAndCategoryIdAsync(Guid userId, Guid categoryId)
    {
        return await _categoryRepository.GetCategoryByUserIdAndCategoryIdAsync(userId, categoryId);
    }

    public Task<Category> UpdateCategoryAsync(Category category)
    {
        return _categoryRepository.UpdateCategoryAsync(category);
    }
}