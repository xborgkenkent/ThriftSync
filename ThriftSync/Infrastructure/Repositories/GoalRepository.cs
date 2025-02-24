using Microsoft.EntityFrameworkCore;
using ThriftSync.Domain.Entities;
using ThriftSync.Domain.Interfaces;
using ThriftSync.Infrastructure.Data;

namespace ThriftSync.Infrastructure.Repositories;

public class GoalRepository : IGoalRepository
{
    private readonly AppDbContext _context;

    public GoalRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Goal?> GetGoalByUserIdAndGoaldIdAsync(Guid userId, Guid goalId)
    {
        var goal = await _context.Goals.Where(x => x.UserId == userId && x.Id == goalId).FirstOrDefaultAsync();
        return goal;
    }

    public async Task<Goal> AddGoalAsync(Goal goal)
    {
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();
        return goal;
    }

    public async Task<IEnumerable<Goal>> GetGoalsByUserIdAsync(Guid userId)
    {
        var goals = await _context.Goals.Where(x => x.UserId == userId).ToListAsync();
        return goals;
    }
}