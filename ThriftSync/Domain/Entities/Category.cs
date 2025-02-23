using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThriftSync.Domain.Entities;

public class Category
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public CategoryType Type { get; set; }
    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    public string Color { get; set; }
    public string Icon { get; set; }
}

public enum CategoryType
{
    Expense,
    Income
}