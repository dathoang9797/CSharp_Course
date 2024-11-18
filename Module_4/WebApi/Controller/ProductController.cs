using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController : BaseController
{
    [HttpGet("{page?}/{size?}")]
    public object GetListProducts(int page = 1, int size = 10)
    {
        var total = Provider.Product.Count();
        return new
        {
            Data = Provider.Product.GetProducts(page, size),
            Pages = (total - 1) / size + 1
        };
    }

    [HttpPost]
    public int Add(Product obj)
    {
        return Provider.Product.Add(obj);
    }
}