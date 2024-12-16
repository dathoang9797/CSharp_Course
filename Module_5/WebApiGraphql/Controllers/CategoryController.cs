using Microsoft.AspNetCore.Mvc;
using WebApiGraphql.Models;

namespace WebApiGraphql.Controllers;

[ApiController, Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private WebStoreContext Context { get; set; }
    public CategoryController(WebStoreContext context) => this.Context = context;

    [HttpGet]
    public List<Category> GetCategories() => Context.Categories.ToList();
}