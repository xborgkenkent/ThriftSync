using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThriftSync.Domain.Entities;

public class Income
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}