using ThriftSync.Domain.Entities;
using ThriftSync.Domain.Interfaces;

namespace ThriftSync.Application.Services;

public class DefaultCategoryService
{
    private readonly IDefaultCategoryRepository _defaultCategoryRepository;

    public DefaultCategoryService(IDefaultCategoryRepository defaultCategoryRepository)
    {
        _defaultCategoryRepository = defaultCategoryRepository;
    }

    public async Task<IEnumerable<DefaultCategory>> GetDefaultCategoriesAsync()
    {
        return await _defaultCategoryRepository.GetCategories();
    }

    public async Task<DefaultCategory?> GetDefaultCategoryByIdAsync(Guid id)
    {
        return await _defaultCategoryRepository.GetCategoryById(id);
    }
}