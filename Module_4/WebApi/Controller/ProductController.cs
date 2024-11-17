using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController : BaseController
{
    [HttpGet]
    public IEnumerable<Category> GetCategories()
    {
        return Provider.Category.GetCategories();
    }

    
}