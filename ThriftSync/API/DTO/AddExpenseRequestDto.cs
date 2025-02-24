namespace ThriftSync.API.DTO;

public class AddExpenseRequestDto
{
    public Guid CategoryId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Tags { get; set; }
}