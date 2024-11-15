using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    public IEnumerable<Category> GetCategories()
    {
        return new List<Category>()
        {
            new() { CategoryId = 1, CategoryName = "Mouse" },
            new() { CategoryId = 2, CategoryName = "Keyboard" },
            new() { CategoryId = 3, CategoryName = "SSD" },
            new() { CategoryId = 4, CategoryName = "HDD" },
            new() { CategoryId = 5, CategoryName = "RAM" },
            new() { CategoryId = 6, CategoryName = "Desktop" },
        };
    }
}