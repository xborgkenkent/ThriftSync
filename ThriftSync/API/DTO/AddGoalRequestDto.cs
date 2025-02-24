namespace ThriftSync.API.DTO;

public class AddGoalRequestDto
{
    public string Title { get; set; }
    public decimal TargetAmount { get; set; }
    public decimal CurrentAmount { get; set; }
    public DateTime Deadline { get; set; }
}