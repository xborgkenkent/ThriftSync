using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThriftSync.Domain.Entities;

public class Report
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    public ReportType Type { get; set; }
    public DateTime GeneratedAt { get; set; }
    public ReportFormat Format { get; set; }
    public string Path { get; set; }
}

public enum ReportType
{
    Monthly, Quarterly, Yearly, Custom
}

public enum ReportFormat
{
    PDF, CSV
}