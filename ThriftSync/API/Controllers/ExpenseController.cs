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
public class ExpenseController : ControllerBase
{
    private readonly ExpenseService _expenseService;

    public ExpenseController(ExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateExpense([FromBody] AddExpenseRequestDto addExpenseRequestDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var expense = _expenseService.AddExpenseAsync(new Expense
        {
            UserId = Guid.Parse(userId),
            CategoryId = addExpenseRequestDto.CategoryId,
            Amount = addExpenseRequestDto.Amount,
            Description = addExpenseRequestDto.Description,
            Date = addExpenseRequestDto.Date,
            Tags = addExpenseRequestDto.Tags,
        });
        return Ok(new { message = expense });
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetExpenses()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var expenses = await _expenseService.GetExpensesByUserIdAsync(Guid.Parse(userId));
        return Ok(expenses);
        
    }
}