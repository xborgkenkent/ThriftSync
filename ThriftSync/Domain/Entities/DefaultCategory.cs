namespace ThriftSync.Domain.Entities;

public class DefaultCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // "Income" or "Expense"
    public string IconUrl { get; set; }
}