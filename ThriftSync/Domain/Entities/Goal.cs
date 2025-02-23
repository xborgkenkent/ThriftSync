using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThriftSync.Domain.Entities;

public class Goal
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public decimal TargetAmount { get; set; }
    public decimal CurrentAmount { get; set; }
    public DateTime Deadline { get; set; }
}