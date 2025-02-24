using ThriftSync.Domain.Entities;

namespace ThriftSync.Domain.Interfaces;

public interface IGoalRepository
{
    Task<Goal?> GetGoalByUserIdAndGoaldIdAsync(Guid userId, Guid goalId);
    Task<Goal> AddGoalAsync(Goal goal);
    Task<IEnumerable<Goal>> GetGoalsByUserIdAsync(Guid userId);
}