using ThriftSync.Domain.Entities;
using ThriftSync.Domain.Interfaces;
using ThriftSync.Infrastructure.Repositories;

namespace ThriftSync.Application.Services;

public class GoalService
{
    private readonly IGoalRepository _goalRepository;

    public GoalService(IGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }

    public async Task<IEnumerable<Goal>> GetGoalsAsync(Guid userId)
    {
        return await _goalRepository.GetGoalsByUserIdAsync(userId);
    }

    public async Task<Goal> AddGoalAsync(Goal goal)
    {
        return await _goalRepository.AddGoalAsync(goal);
    }

    public async Task<Goal?> GetGoalByUserIdAndGoaldIdAsync(Guid userId, Guid goalId)
    {
        return await _goalRepository.GetGoalByUserIdAndGoaldIdAsync(userId, goalId);
    }
}