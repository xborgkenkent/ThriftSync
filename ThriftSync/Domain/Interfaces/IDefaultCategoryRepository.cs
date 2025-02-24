using ThriftSync.Domain.Entities;

namespace ThriftSync.Domain.Interfaces;

public interface IDefaultCategoryRepository
{
    Task<IEnumerable<DefaultCategory>> GetCategories();
    Task<DefaultCategory?> GetCategoryById(Guid id);
}