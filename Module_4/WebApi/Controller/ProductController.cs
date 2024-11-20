using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Controller;

[ApiController]
[Route("api/product")]
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
    [Route("add")]
    public int Add(Product obj)
    {
        return Provider.Product.Add(obj);
    }

    [HttpPost]
    [Route("delete/{id}")]
    public int Delete(Image obj)
    {
        Helper.Delete(obj.ImageUrl);
        return Provider.Product.Delete(obj.Id);
    }

    [HttpGet("{id}")]
    public Product? GetProduct([FromRoute] int id)
    {
        return Provider.Product.GetProduct(id);
    }

    [HttpPost]
    [Route("edit/{id}")]
    public int Edit([FromRoute] int id, Product obj)
    {
        var product = Provider.Product.GetProduct(id);
        var imageUrl = Provider.Product.GetImageUrl(obj.ProductId);
        if (imageUrl != null && !imageUrl.Equals(obj.ImageUrl))
            Helper.Delete(imageUrl);

        obj.CreatedDate = product?.CreatedDate ?? DateTime.UtcNow;
        obj.UpdateDate = DateTime.UtcNow;

        return Provider.Product.Edit(obj);
    }
}