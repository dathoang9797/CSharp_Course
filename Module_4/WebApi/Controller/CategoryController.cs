using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : BaseController
{
    [HttpGet]
    public IEnumerable<Category> GetCategories()
    {
        return Provider.Category.GetCategories();
    }

    [HttpGet("{id}")]
    public Category? GetCategory(int id)
    {
        return Provider.Category.GetCategory(id);
    }

    [HttpPost]
    public int Add([FromBody] Category obj)
    {
        return Provider.Category.Add(obj);
    }
    
    [HttpPut]
    public int Edit(Category obj)
    {
        return Provider.Category.Edit(obj);
    }
    
    [HttpDelete("{id}")]
    public int Delete(int id)
    {
        return Provider.Category.Delete(id);
    }
}