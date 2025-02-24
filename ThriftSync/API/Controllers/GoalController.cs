using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ThriftSync.API.DTO;
using ThriftSync.Application.Services;
using ThriftSync.Domain.Entities;

namespace ThriftSync.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GoalController : ControllerBase
{
    private readonly GoalService _goalService;

    public GoalController(GoalService goalService)
    {
        _goalService = goalService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateGoal([FromBody] AddGoalRequestDto addGoalRequestDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return Unauthorized();

        var goal = await _goalService.AddGoalAsync(new Goal
        {
            UserId = Guid.Parse(userId),
            Title = addGoalRequestDto.Title,
            TargetAmount = addGoalRequestDto.TargetAmount,
            CurrentAmount = addGoalRequestDto.CurrentAmount,
            Deadline = addGoalRequestDto.Deadline,
        });

        return Ok(new { message = "Goal created successfully", goal });
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetGoals()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return Unauthorized();

        var goals = await _goalService.GetGoalsAsync(Guid.Parse(userId));

        return Ok(new { message = "Goals retrieved successfully", goals });
    }

}