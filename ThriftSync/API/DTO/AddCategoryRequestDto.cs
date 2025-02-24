using ThriftSync.Domain.Entities;

namespace ThriftSync.API.DTO;

public class AddCategoryRequestDto
{
    public string Name { get; set; }
    public CategoryType Type { get; set; }
    public string Color { get; set; }
    public Guid CategoryId { get; set; }
}