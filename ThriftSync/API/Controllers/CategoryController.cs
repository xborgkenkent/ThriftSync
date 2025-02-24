using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThriftSync.API.DTO;
using ThriftSync.Application.Services;
using ThriftSync.Domain.Entities;

namespace ThriftSync.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;
    private readonly DefaultCategoryService _defaultCategoryService;

    public CategoryController(CategoryService categoryService, DefaultCategoryService defaultCategoryService)
    {
        _categoryService = categoryService;
        _defaultCategoryService = defaultCategoryService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] AddCategoryRequestDto addCategoryRequestDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var defaultCategory = _defaultCategoryService.GetDefaultCategoryByIdAsync(addCategoryRequestDto.CategoryId);
        var category = _categoryService.AddCategoryAsync(new Category
        {
            Name = addCategoryRequestDto.Name,
            UserId = Guid.Parse(userId),
            Type = addCategoryRequestDto.Type,
            Color = addCategoryRequestDto.Color,
            Icon = defaultCategory.Result.IconUrl,
        });
        return Ok(new { message = category });
    }
    
}