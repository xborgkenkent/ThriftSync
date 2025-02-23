using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThriftSync.Domain.Entities;

public class Budget
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }
    public decimal Amount { get; set; }
    public Period Period { get; set; } 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public enum Period
{
    Monthly,
    Quarterly,
    Annually
}