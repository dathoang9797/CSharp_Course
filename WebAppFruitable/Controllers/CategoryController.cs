using Microsoft.AspNetCore.Mvc;
using WebAppFruitable.Model;
using WebAppFruitables;

namespace WebAppFruitable.Controllers;

public class CategoryController : BaseController
{
    [HttpGet]
    [Route("category/{id}")]
    public IActionResult Index([FromRoute] int id)
    {
        try
        {
            var listProduct = new List<Product>();
            if (id == 0)
            {
                var products = Provider.Product.GetProducts();
                if (products.Any())
                    listProduct = products;
            }
            else
            {
                var category = Provider.Category.GetCategory(id);
                if (category != null)
                    listProduct = category.Products;
            }


            var data = Json(listProduct);
            var rsp = Ok(data);
            return rsp;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}